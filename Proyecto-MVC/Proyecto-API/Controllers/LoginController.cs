using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ProyectoModels;
using IPracticaProgramada_JoseMataAPI.Data;

namespace Proyecto_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ProyectoContext _context;

        public LoginController(ProyectoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(string correoElectronico, string contraseña)
        {
            
            if (string.IsNullOrWhiteSpace(correoElectronico) || string.IsNullOrWhiteSpace(contraseña))
            {
                return BadRequest("Por favor, ingrese su correo electrónico y contraseña.");
            }

            
            var usuario = _context.Usuarios.FirstOrDefault(u => u.CorreoElectronico == correoElectronico);

            if (usuario == null)
            {
                
                return NotFound("El usuario no existe.");
            }

            
            if (usuario.Contraseña != contraseña)
            {
                
                return Unauthorized("La contraseña es incorrecta.");
            }

            
            return Ok("Inicio de sesión exitoso.");
        }
    }
}
