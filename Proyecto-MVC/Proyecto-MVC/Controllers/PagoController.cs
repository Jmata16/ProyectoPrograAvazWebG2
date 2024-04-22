using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoModels;
using ProyectyoG2.Data;
using System.Linq;

namespace Proyecto_MVC.Controllers
{
    public class PagoController : Controller
    {
        private readonly ProyectoContext _context;

        public PagoController(ProyectoContext context)
        {
            _context = context;
        }

        // GET: Pago
        public IActionResult Pago()
        {
            // Obtener los productos en el carrito desde la base de datos
            var productosEnCarrito = _context.Carrito
                                             .Include(c => c.Producto)
                                             .ToList();

            // Calcular el total de la compra
            decimal totalCompra = productosEnCarrito.Sum(item => item.Producto.Precio * item.Cantidad);

            // Pasar el total de la compra a la vista
            ViewData["TotalCompra"] = totalCompra;

            return View(productosEnCarrito);
        }

        // POST: Pago/ConfirmarPago
        [HttpPost]
        public IActionResult ConfirmarPago()
        {
            // Simular el proceso de pago (no se realiza ningún procesamiento real)

            // Actualizar el estado del pedido en la base de datos (simulado)
            // Aquí podrías agregar la lógica para marcar los productos como comprados, vaciar el carrito, etc.

            // Eliminar todos los elementos del carrito
            var carritoItems = _context.Carrito.ToList();
            _context.Carrito.RemoveRange(carritoItems);
            _context.SaveChanges();

            // Mostrar un mensaje de confirmación al usuario
            TempData["MensajePago"] = "¡Gracias por su compra! El pago se ha completado correctamente.";

            return RedirectToAction("Pagado"); // Redirigir a la página de inicio u otra página relevante
        }


        public IActionResult Pagado()
        {

            return View();
        }
    }
}
