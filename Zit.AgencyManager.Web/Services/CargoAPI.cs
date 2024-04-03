using System.Net.Http.Json;
using Zit.AgencyManager.Web.Request;
using Zit.AgencyManager.Web.Response;

namespace Zit.AgencyManager.Web.Services
{
    public class CargoAPI
    {
        private readonly HttpClient _httpClient;

        public CargoAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<CargoResponse>?> GetCargosAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<CargoResponse>>("cargos");
        }

        public async Task<bool> AddCargoAsync(CargoRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("cargos", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCargoAsync(int cargoId)
        {
            var response = await _httpClient.DeleteAsync($"cargos/{cargoId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCargoAsync(int id, CargoRequestEdit request)
        {
            var response = await _httpClient.PutAsJsonAsync($"cargos/{id}", request);
            return response.IsSuccessStatusCode;
        }
    }
}
