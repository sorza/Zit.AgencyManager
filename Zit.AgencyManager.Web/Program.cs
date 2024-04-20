using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Zit.AgencyManager.Web.Services;

namespace Zit.AgencyManager.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddMudServices();

            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped<AuthenticationStateProvider, AuthAPI>();
            builder.Services.AddScoped(sp => (AuthAPI) sp.GetRequiredService<AuthenticationStateProvider>());

            builder.Services.AddScoped<TitleService>();            
            builder.Services.AddScoped<CookieHandler>();

            builder.Services.AddTransient<AgenciaAPI>();
            builder.Services.AddTransient<CargoAPI>();
            builder.Services.AddTransient<ColaboradorAPI>();
            builder.Services.AddTransient<UsuarioAPI>();
            builder.Services.AddTransient<EmpresaAPI>();
            builder.Services.AddTransient<ContratoAPI>();
            builder.Services.AddTransient<CaixaAPI>();

            builder.Services.AddHttpClient("API", client => {
                client.BaseAddress = new Uri(builder.Configuration["APIServer:Url"]!);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            }).AddHttpMessageHandler<CookieHandler>();

            await builder.Build().RunAsync();
        }
    }
}
