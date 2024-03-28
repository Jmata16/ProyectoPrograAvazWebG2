using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ProyectoModels;
using IPracticaProgramada_JoseMataAPI.Data;

namespace Proyecto_MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Registros()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = new Usuarios(); // Crear una nueva instancia del modelo Usuarios

                    // Asignar valores a las propiedades del modelo desde el formulario
                    usuario.Nombre = Request.Form["Nombre"];
                    usuario.CorreoElectronico = Request.Form["CorreoElectronico"];
                    usuario.Contraseña = Request.Form["Contraseña"];
                    usuario.Rol_ID = 2; // Puedes establecer un valor predeterminado aquí o en el modelo

                    var httpClient = _httpClientFactory.CreateClient();

                    // URL de tu API para registrar un usuario
                    var url = "https://localhost:7076/api/Usuarios";

                    // Serializar el objeto usuario a JSON
                    var jsonUsuario = JsonSerializer.Serialize(usuario);

                    // Configurar el contenido de la solicitud HTTP
                    var content = new StringContent(jsonUsuario, Encoding.UTF8, "application/json");

                    // Enviar la solicitud POST a la API
                    var response = await httpClient.PostAsync(url, content);

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Login)); // Redireccionar al login después de registrar el usuario
                    }
                    else
                    {
                        // Manejar el error de la API si es necesario
                        ModelState.AddModelError(string.Empty, "Error al registrar el usuario.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error inesperado
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
