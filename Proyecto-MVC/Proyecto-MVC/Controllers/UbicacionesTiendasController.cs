using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoModels;
using Proyecto_MVC.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_MVC.Controllers
{
    [Authorize(Policy = "RequireAdminRolID")]
    public class UbicacionesTiendasController : Controller
    {
        private readonly IUbicacionTiendaService _ubicacionTiendaService;

        public UbicacionesTiendasController(IUbicacionTiendaService ubicacionTiendaService)
        {
            _ubicacionTiendaService = ubicacionTiendaService;
        }

        public async Task<IActionResult> Index()
        {
            var ubicacionesTiendas = await _ubicacionTiendaService.GetUbicacionesTiendasAsync();
            return View(ubicacionesTiendas);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UbicacionTienda ubicacionTienda)
        {
            if (ModelState.IsValid)
            {
                await _ubicacionTiendaService.CreateUbicacionTiendaAsync(ubicacionTienda);
                return RedirectToAction(nameof(Index));
            }
            return View(ubicacionTienda);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ubicacionTienda = await _ubicacionTiendaService.GetUbicacionTiendaByIdAsync(id.Value);
            if (ubicacionTienda == null)
            {
                return NotFound();
            }

            return View(ubicacionTienda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UbicacionTienda ubicacionTienda)
        {
            if (id != ubicacionTienda.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _ubicacionTiendaService.UpdateUbicacionTiendaAsync(id, ubicacionTienda);
                }
                catch (Exception)
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
                return RedirectToAction(nameof(Index));
            }
            return View(ubicacionTienda);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ubicacionTienda = await _ubicacionTiendaService.GetUbicacionTiendaByIdAsync(id.Value);
            if (ubicacionTienda == null)
            {
                return NotFound();
            }

            return View(ubicacionTienda);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ubicacionTiendaService.DeleteUbicacionTiendaAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool UbicacionTiendaExists(int id)
        {
            
            return true;
        }
    }
}
