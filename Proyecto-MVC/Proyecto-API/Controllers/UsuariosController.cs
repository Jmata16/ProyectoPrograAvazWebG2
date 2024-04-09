using ProyectyoG2.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoModels;
using System;
using System.Linq;

namespace Proyecto_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ProyectoContext _context;

        public UsuariosController(ProyectoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PostUsuario(Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            var existingUser = _context.Usuarios.FirstOrDefault(u => u.CorreoElectronico == usuarios.CorreoElectronico);
            if (existingUser != null)
            {
                return Conflict("Ya existe un usuario con este correo electrónico.");
            }

            usuarios.Rol_ID = 2;

            try
            {
                _context.Usuarios.Add(usuarios);
                _context.SaveChanges();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Usuarios> GetUsuario(int id)
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(u => u.ID == id);

                if (usuario == null)
                {
                    return NotFound();
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult PutUsuario(int id, Usuarios usuario)
        {
            if (id != usuario.ID)
            {
                return BadRequest(); 
            }

            try
            {
                var usuarioExistente = _context.Usuarios.Find(id);
                if (usuarioExistente == null)
                {
                    return NotFound(); 
                }

                
                usuarioExistente.Nombre = usuario.Nombre;
                usuarioExistente.CorreoElectronico = usuario.CorreoElectronico;
                usuarioExistente.Contraseña = usuario.Contraseña;
                usuarioExistente.Rol_ID = usuario.Rol_ID;

                _context.SaveChanges();

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);
                if (usuario == null)
                {
                    return NotFound(); 
                }

                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuarios>> GetUsuarios()
        {
            try
            {
                var usuarios = _context.Usuarios.ToList();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}