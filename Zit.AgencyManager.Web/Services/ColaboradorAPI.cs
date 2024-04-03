using System.Net.Http.Json;
using Zit.AgencyManager.Web.Request;
using Zit.AgencyManager.Web.Response;

namespace Zit.AgencyManager.Web.Services
{
    public class ColaboradorAPI
    {
        private readonly HttpClient _httpClient;

        public ColaboradorAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<ColaboradorResponse>?> GetColaboradoresAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<ColaboradorResponse>>("colaboradores");
        }

        public async Task<bool> AddColaboradorAsync(ColaboradorRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("colaboradores", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteColaboradorAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"colaboradores/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<ColaboradorResponse?> GetColaboradorAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ColaboradorResponse>($"colaboradores/{id}");
        }

        public async Task<bool> UpdateColaboradorAsync(int id, ColaboradorRequestEdit request)
        {
            var response = await _httpClient.PutAsJsonAsync($"colaboradores/{id}", request);
            return response.IsSuccessStatusCode;
        }
    }
}
