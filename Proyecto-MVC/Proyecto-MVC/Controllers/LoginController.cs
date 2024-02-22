using Microsoft.AspNetCore.Mvc;

namespace Proyecto_MVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
