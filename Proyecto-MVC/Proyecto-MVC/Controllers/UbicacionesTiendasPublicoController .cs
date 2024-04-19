using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoModels;
using Proyecto_MVC.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_MVC.Controllers
{
   
    public class UbicacionesTiendasPublicoController : Controller
    {
        private readonly IUbicacionTiendaService _ubicacionTiendaService;

        public UbicacionesTiendasPublicoController(IUbicacionTiendaService ubicacionTiendaService)
        {
            _ubicacionTiendaService = ubicacionTiendaService;
        }

        public async Task<IActionResult> Index()
        {
            var ubicacionesTiendas = await _ubicacionTiendaService.GetUbicacionesTiendasAsync();
            return View(ubicacionesTiendas);
        }


    }
}
