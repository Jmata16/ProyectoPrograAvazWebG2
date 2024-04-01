using Microsoft.EntityFrameworkCore;
using ProyectoModels;
using System.Text.RegularExpressions;

namespace ProyectyoG2.Data
{
    public class ProyectoContext : DbContext
    {
        public ProyectoContext(DbContextOptions<ProyectoContext> options)
            : base(options)
        {
        }

        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
  



    }
}
