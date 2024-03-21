using Microsoft.EntityFrameworkCore;
using ProyectoModels;

namespace IPracticaProgramada_JoseMataAPI.Data
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
