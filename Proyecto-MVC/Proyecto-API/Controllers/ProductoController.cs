using Microsoft.AspNetCore.Mvc;
using ProyectyoG2.Data;

namespace Proyecto_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly ProyectoContext _context;

        public ProductoController(ProyectoContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult Product(string Nombre, int Precio, string Descripcion)
        {
            if (string.IsNullOrWhiteSpace(Nombre) || Precio == 0 || string.IsNullOrWhiteSpace(Descripcion))
            {
                return BadRequest("Por favor, ingrese el nombre, precio y descripción del producto.");
            }

            return Ok("Datos ingresados exitosamente");
        }

    }
}

