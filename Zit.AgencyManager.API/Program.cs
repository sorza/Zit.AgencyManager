
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("wasm",
                    builder => builder.WithOrigins("https://localhost:7040")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            builder.Services
                .AddIdentityApiEndpoints<Usuario>()
                .AddEntityFrameworkStores<AgencyManagerContext>();

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
            builder.Services.AddTransient<DAL<Cliente>>();
            builder.Services.AddTransient<DAL<Movimentacao>>();
            builder.Services.AddTransient<DAL<Endereco>>();
            builder.Services.AddTransient<DAL<Usuario>>();

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseCors("wasm");

            app.AddEndpointsContatos();
            app.AddEndpointsCargos();
            app.AddEndpointsColaboradores();
            app.AddEndpointsEmpresas();
            app.AddEndpointsContratoAgenciaEmpresas();
            app.AddEndpointsCaixas();
            app.AddEndpointsVendas();
            app.AddEndpointsLocalidades();
            app.AddEndpointsVendasVirtuais();
            app.AddEndpointsClientes();
            app.AddEndpointsMovimentacoes();
            app.AddEndpointsUsuario();

            app.MapGroup("auth").MapIdentityApi<Usuario>().WithTags("Autorização");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.Run();
        }
    }
}
