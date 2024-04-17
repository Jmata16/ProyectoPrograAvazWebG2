using ProyectoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_MVC.Services
{
    public interface IUbicacionTiendaService
    {
        Task<List<UbicacionTienda>> GetUbicacionesTiendasAsync();
        Task<UbicacionTienda> GetUbicacionTiendaByIdAsync(int id);
        Task CreateUbicacionTiendaAsync(UbicacionTienda ubicacionTienda);
        Task UpdateUbicacionTiendaAsync(int id, UbicacionTienda ubicacionTienda);
        Task DeleteUbicacionTiendaAsync(int id);
    }
}
