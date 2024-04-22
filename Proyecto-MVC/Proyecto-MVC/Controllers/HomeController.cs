using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_MVC.Models;
using ProyectyoG2.Data;
using System.Diagnostics;
using System.Security.Claims;

namespace Proyecto_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProyectoContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ProyectoContext context)
        {
            _context = context;
            _logger = logger;
        }


        public IActionResult Index()
        {
            var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewData["UserID"] = usuarioId;


            var productos = _context.Productos.ToList();


            return View(productos);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }

}
