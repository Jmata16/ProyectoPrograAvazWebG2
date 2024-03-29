using Microsoft.EntityFrameworkCore;
using ProyectoModels;

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

    }
}
