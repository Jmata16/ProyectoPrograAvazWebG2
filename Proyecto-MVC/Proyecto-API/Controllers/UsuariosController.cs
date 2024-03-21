using IPracticaProgramada_JoseMataAPI.Data;
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
    }
}