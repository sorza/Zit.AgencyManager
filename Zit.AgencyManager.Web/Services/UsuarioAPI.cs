using System.Net.Http.Json;
using Zit.AgencyManager.Web.Request;

namespace Zit.AgencyManager.Web.Services
{
    public class UsuarioAPI
    {
        protected readonly HttpClient _httpClient;

        public UsuarioAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task<int> GetUsuarioIdAsync(string username)
        {
            return await _httpClient.GetFromJsonAsync<int>($"usuarios/{username}");            
        }

        
        public async Task<bool> AddUsuarioAsync(UsuarioRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("auth/register", request);
            return response.IsSuccessStatusCode;
        }
    }
}
