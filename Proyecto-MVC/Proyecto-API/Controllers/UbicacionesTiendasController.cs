using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoModels;
using ProyectyoG2.Data;

namespace ProyectoG2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionesTiendasController : ControllerBase
    {
        private readonly ProyectoContext _context;

        public UbicacionesTiendasController(ProyectoContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UbicacionTienda>>> GetUbicacionesTiendas()
        {
            return await _context.UbicacionesTiendas.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UbicacionTienda>> GetUbicacionTienda(int id)
        {
            var ubicacionTienda = await _context.UbicacionesTiendas.FindAsync(id);

            if (ubicacionTienda == null)
            {
                return NotFound();
            }

            return ubicacionTienda;
        }

        [HttpPost]
        public async Task<ActionResult<UbicacionTienda>> PostUbicacionTienda(UbicacionTienda ubicacionTienda)
        {
            _context.UbicacionesTiendas.Add(ubicacionTienda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUbicacionTienda", new { id = ubicacionTienda.ID }, ubicacionTienda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUbicacionTienda(int id, UbicacionTienda ubicacionTienda)
        {
            if (id != ubicacionTienda.ID)
            {
                return BadRequest();
            }

            _context.Entry(ubicacionTienda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UbicacionTiendaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUbicacionTienda(int id)
        {
            var ubicacionTienda = await _context.UbicacionesTiendas.FindAsync(id);
            if (ubicacionTienda == null)
            {
                return NotFound();
            }

            _context.UbicacionesTiendas.Remove(ubicacionTienda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UbicacionTiendaExists(int id)
        {
            return _context.UbicacionesTiendas.Any(e => e.ID == id);
        }
    }
}
