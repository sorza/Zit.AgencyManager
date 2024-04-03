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

            builder.Services.AddTransient<AgenciaAPI>();
            builder.Services.AddTransient<CargoAPI>();
            builder.Services.AddTransient<ColaboradorAPI>();
            builder.Services.AddTransient<UsuarioAPI>();

            builder.Services.AddHttpClient("API", client => {
                client.BaseAddress = new Uri(builder.Configuration["APIServer:Url"]!);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            await builder.Build().RunAsync();
        }
    }
}
