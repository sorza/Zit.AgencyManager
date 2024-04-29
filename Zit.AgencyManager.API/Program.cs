using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Zit.AgencyManager.API.Endpoints;
using Zit.AgencyManager.Dados.Banco;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AgencyManagerContext>((options) => {
                options
                        .UseSqlServer(builder.Configuration["ConnectionStrings:AgencyManagerDB"])
                        .UseLazyLoadingProxies();
            });

            builder.Services
                .AddIdentityApiEndpoints<Usuario>()
                .AddEntityFrameworkStores<AgencyManagerContext>();     

            builder.Services.AddAuthorization();

            builder.Services.AddTransient<DAL<Usuario>>();
            builder.Services.AddTransient<DAL<Agencia>>();
            builder.Services.AddTransient<DAL<Cargo>>();
            builder.Services.AddTransient<DAL<Colaborador>>();
            builder.Services.AddTransient<DAL<Empresa>>();
            builder.Services.AddTransient<DAL<Contato>>();
            builder.Services.AddTransient<DAL<ContratoAgenciaEmpresa>>();
            builder.Services.AddTransient<DAL<Caixa>>();
            builder.Services.AddTransient<DAL<Venda>>();
            builder.Services.AddTransient<DAL<Localidade>>();
            builder.Services.AddTransient<DAL<VendaVirtual>>();
            builder.Services.AddTransient<DAL<Movimentacao>>();
            builder.Services.AddTransient<DAL<Endereco>>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("wasm",
                    builder => builder.WithOrigins("https://localhost:7040")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            var app = builder.Build();

            app.UseCors("wasm");

            app.UseStaticFiles();
            app.UseAuthorization();

            app.AddEndpointsContatos();
            app.AddEndpointsCargos();
            app.AddEndpointsColaboradores();
            app.AddEndpointsEmpresas();
            app.AddEndpointsContratoAgenciaEmpresas();
            app.AddEndpointsCaixas();
            app.AddEndpointsVendas();
            app.AddEndpointsLocalidades();
            app.AddEndpointsVendasVirtuais();
            app.AddEndpointsMovimentacoes();
            app.AddEndpointsUsuario();

            app.MapGroup("auth").MapIdentityApi<Usuario>().WithTags("Autorização");

            app.MapPost("auth/logout", async ([FromServices] SignInManager<Usuario> signInManager) =>
            {
                await signInManager.SignOutAsync();
                return Results.Ok();
            }).RequireAuthorization().WithTags("Autorização");
           

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }          

            app.UseHttpsRedirection();

            app.Run();
        }
    }
}
