using ProyectoModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Proyecto_MVC.Services
{
    public class UbicacionTiendaService : IUbicacionTiendaService
    {
        private readonly HttpClient _httpClient;

        public UbicacionTiendaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UbicacionTienda>> GetUbicacionesTiendasAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7076/api/UbicacionesTiendas");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<UbicacionTienda>>();
        }

        public async Task<UbicacionTienda> GetUbicacionTiendaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7076/api/UbicacionesTiendas/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<UbicacionTienda>();
        }

        public async Task CreateUbicacionTiendaAsync(UbicacionTienda ubicacionTienda)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7076/api/UbicacionesTiendas", ubicacionTienda);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateUbicacionTiendaAsync(int id, UbicacionTienda ubicacionTienda)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7076/api/UbicacionesTiendas/{id}", ubicacionTienda);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUbicacionTiendaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7076/api/UbicacionesTiendas/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
