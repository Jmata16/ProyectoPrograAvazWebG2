using Microsoft.AspNetCore.Mvc;
using ProyectoModels;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Proyecto_MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AdminController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> TablaUsuarios()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7076/api/Usuarios");

            if (response.IsSuccessStatusCode)
            {
                var users = await response.Content.ReadFromJsonAsync<List<Usuarios>>();
                return View(users);
            }
            else
            {
                return View("Error");
            }
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7076/api/Usuarios/{id}");

            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<Usuarios>();
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
            else
            {
                return View("Error");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuarios usuario)
        {
            if (id != usuario.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient();
                var content = new StringContent(JsonSerializer.Serialize(usuario), Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"https://localhost:7076/api/Usuarios/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    
                    return RedirectToAction("TablaUsuarios", "Admin");
                }
                else
                {
                    return View("Error");
                }
            }
            return View(usuario);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7076/api/Usuarios/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Error");
            }
        }
    }
}
