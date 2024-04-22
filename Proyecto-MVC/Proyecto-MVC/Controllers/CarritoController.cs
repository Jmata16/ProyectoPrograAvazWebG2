using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoModels;
using ProyectyoG2.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_MVC.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ProyectoContext _context;

        public CarritoController(ProyectoContext context)
        {
            _context = context;
        }

        // GET: Carrito
        public IActionResult Index()
        {
            // Obtener los productos en el carrito desde la base de datos
            var productosEnCarrito = _context.Carrito
                                             .Include(c => c.Producto)  // Incluye la información del producto relacionado
                                             .ToList();

            // Pasar la lista de productos en el carrito a la vista
            return View(productosEnCarrito);
        }




        // GET: Carrito/AddToCart/5
        public async Task<IActionResult> AddToCart(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            var carritoItem = new Carrito
            {
                ProductoID = producto.ID,
                Precio = producto.Precio,
                Producto = producto
            };

            _context.Add(carritoItem);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Carrito/RemoveFromCart/5
        public async Task<IActionResult> RemoveFromCart(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carritoItem = await _context.Carrito.FindAsync(id);
            if (carritoItem == null)
            {
                return NotFound();
            }

            _context.Carrito.Remove(carritoItem);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Carrito/ClearCart
        public async Task<IActionResult> ClearCart()
        {
            var carritoItems = await _context.Carrito.ToListAsync();
            _context.Carrito.RemoveRange(carritoItems);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AgregarAlCarrito(int productoId)
        {
            // Buscar el producto en la base de datos
            var producto = _context.Productos.FirstOrDefault(p => p.ID == productoId);

            if (producto != null)
            {
                // Crear un nuevo objeto Carrito y asignarle el producto
                var carritoItem = new Carrito
                {
                    ProductoID = producto.ID,
                    Precio = producto.Precio,
                    Producto = producto,
                    Cantidad = 1 // Asignar un valor predeterminado para la cantidad
                };

                // Agregar el objeto Carrito a la base de datos
                _context.Carrito.Add(carritoItem);
                _context.SaveChanges(); // Guardar los cambios en la base de datos

                // Después de agregar el producto al carrito, redirigir a la vista del carrito
                return RedirectToAction("Index");
            }
            else
            {
                // Si el producto no se encuentra en la base de datos, puedes manejar el error de alguna manera
                // Por ejemplo, puedes mostrar un mensaje de error o redirigir a una página de error
                return RedirectToAction("Index"); // Redirigir a la vista del carrito en caso de error
            }
        }



    }

}

