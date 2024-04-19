using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ProyectoModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Net;
using System.Security.Claims;

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
        public async Task<IActionResult> Registro(Usuarios usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var response = await RegistrarUsuarioEnAPI(usuario);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Login));
                    }
                    else
                    {
                        if (response.StatusCode == HttpStatusCode.Conflict)
                        {
                            ModelState.AddModelError(string.Empty, "Ya existe un usuario con este correo electrónico.");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Error al registrar el usuario.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            }

            return View(usuario);
        }

        private async Task<HttpResponseMessage> RegistrarUsuarioEnAPI(Usuarios usuario)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var url = "https://localhost:7076/api/Usuarios";
                var jsonUsuario = JsonSerializer.Serialize(usuario);
                var content = new StringContent(jsonUsuario, Encoding.UTF8, "application/json");

                return await httpClient.PostAsync(url, content);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string correoElectronico, string contraseña)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(correoElectronico) || string.IsNullOrWhiteSpace(contraseña))
                {
                    ModelState.AddModelError(string.Empty, "Por favor, ingrese su correo electrónico y contraseña.");
                    return View();
                }

                var httpClient = _httpClientFactory.CreateClient();
                var url = $"https://localhost:7076/api/Login?correoElectronico={correoElectronico}&contraseña={contraseña}";

                var response = await httpClient.PostAsync(url, null);

                if (response.IsSuccessStatusCode)
                {

                    var content = await response.Content.ReadAsStringAsync();


                    var usuario = JsonSerializer.Deserialize<Usuarios>(content);


                    var nombre = usuario.Nombre;
                    var correo = usuario.CorreoElectronico;
                    var rolId = usuario.Rol_ID;

                    var id = usuario.ID;

                    ViewData["RolID"] = rolId;
                    ViewData["UserID"] = id;


                    var claims = new List<Claim>
                     {
                          new Claim(ClaimTypes.Name, usuario.Nombre),
                        new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                          new Claim("rol_ID", usuario.Rol_ID.ToString())

                     };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    

                    var authProperties = new AuthenticationProperties
                    {

                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("Index", "Home");
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    ModelState.AddModelError(string.Empty, "El usuario no existe.");
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    ModelState.AddModelError(string.Empty, "La contraseña es incorrecta.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error en el inicio de sesión. Por favor, inténtelo de nuevo más tarde.");
                }
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError(string.Empty, $"Error de comunicación con el servidor: {ex.Message}");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error inesperado: {ex.Message}");
            }


            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CambiarContraseña()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (id != null)
            {
                ViewData["UserID"] = id;
                return View();
            }
            else
            {
                
                return RedirectToAction("Index", "Home");
            }
        }



        [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> CambiarContraseña(int id, string nuevaContraseña)
{
    try
    {
        var httpClient = _httpClientFactory.CreateClient();
        var url = $"https://localhost:7076/api/Login/cambiar-contraseña?id={id}&nuevaContraseña={nuevaContraseña}";

        var response = await httpClient.PostAsync(url, null);

        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Contraseña cambiada exitosamente.";
            return RedirectToAction("Index", "Home");
        }
        else if (response.StatusCode == HttpStatusCode.NotFound)
        {
            TempData["ErrorMessage"] = "El usuario no existe.";
        }
        else
        {
            TempData["ErrorMessage"] = "Error al cambiar la contraseña.";
        }
    }
    catch (HttpRequestException ex)
    {
        TempData["ErrorMessage"] = $"Error de comunicación con el servidor: {ex.Message}";
    }
    catch (Exception ex)
    {
        TempData["ErrorMessage"] = $"Error inesperado: {ex.Message}";
    }

    return RedirectToAction("Index", "Home");
}



    }
}
