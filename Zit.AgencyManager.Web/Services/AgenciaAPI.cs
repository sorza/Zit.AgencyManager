using System.Net.Http.Json;
using Zit.AgencyManager.Web.Request;
using Zit.AgencyManager.Web.Response;

namespace Zit.AgencyManager.Web.Services
{
    public class AgenciaAPI
    {
        private readonly HttpClient _httpClient;

        public AgenciaAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<AgenciaResponse>?> GetAgenciasAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<AgenciaResponse>>("agencias");
        }

        public async Task<bool> AddAgenciaAsync(AgenciaRequest agencia)
        {
            var response = await _httpClient.PostAsJsonAsync("agencias", agencia);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAgenciaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"agencias/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<AgenciaResponse?> GetAgenciaPorIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<AgenciaResponse>($"agencias/{id}");
        }

        public async Task<bool> UpdateAgenciaAsync(int id, AgenciaRequestEdit request)
        {
            var response = await _httpClient.PutAsJsonAsync($"agencias/{id}", request);
            return response.IsSuccessStatusCode;
        }
    }
}
