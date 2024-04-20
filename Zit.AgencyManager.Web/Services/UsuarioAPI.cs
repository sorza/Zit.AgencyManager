using System.Net.Http.Json;
using Zit.AgencyManager.Web.Request;
using Zit.AgencyManager.Web.Response;

namespace Zit.AgencyManager.Web.Services
{
    public class UsuarioAPI
    {
        protected readonly HttpClient _httpClient;

        public UsuarioAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task<UsuarioResponse?> GetUsuarioAsync(string username)
        {
            return await _httpClient.GetFromJsonAsync<UsuarioResponse>($"usuarios/{username}");            
        }
        
        public async Task<bool> AddUsuarioAsync(UsuarioRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("auth/register", request);
            return response.IsSuccessStatusCode;
        }
    }
}
