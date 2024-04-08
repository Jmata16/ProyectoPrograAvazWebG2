using Microsoft.EntityFrameworkCore;
using ProyectyoG2.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProyectoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProyectoDB")));

builder.Services.AddHttpClient();

// Configuración de autenticación de cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Login";
        // tiempo que la sesion esta abierta 
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

    });

var app = builder.Build();

// Configurar middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Configurar autenticación
app.UseAuthentication();
app.UseAuthorization();

// Configurar rutas de controlador
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
