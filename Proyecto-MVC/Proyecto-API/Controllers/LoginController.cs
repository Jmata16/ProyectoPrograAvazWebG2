using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ProyectoModels;
using ProyectyoG2.Data;

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

            return Ok(usuario);
        }

        [HttpPost("cambiar-contraseña")]
        public IActionResult CambiarContraseña(int id, string nuevaContraseña)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.ID == id);

            if (usuario == null)
            {
                return NotFound("El usuario no existe.");
            }

            

            usuario.Contraseña = nuevaContraseña;
            _context.SaveChanges();

            return Ok("Contraseña cambiada exitosamente.");
        }
    }
}