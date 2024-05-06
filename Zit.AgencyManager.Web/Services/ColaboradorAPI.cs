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

        public async Task<ICollection<ColaboradorResponse>?> ListAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<ColaboradorResponse>>("colaboradores");
        }

        public async Task<bool> AddAsync(ColaboradorRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("colaboradores", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"colaboradores/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<ColaboradorResponse?> GetAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ColaboradorResponse>($"colaboradores/{id}");
        }
        
        public async Task<ColaboradorResponse?> GetByUsernameAsync(string username)
        {
            return await _httpClient.GetFromJsonAsync<ColaboradorResponse>($"colaboradores/usuario/{username}");
        }

        public async Task<bool> UpdateAsync(int id, ColaboradorRequestEdit request)
        {
            var response = await _httpClient.PutAsJsonAsync($"colaboradores/{id}", request);
            return response.IsSuccessStatusCode;
        }
    }
}
