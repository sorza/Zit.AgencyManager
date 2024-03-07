
using Microsoft.EntityFrameworkCore;
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

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<DAL<Agencia>>();

            builder.Services.AddCors(
                options => options.AddPolicy(
                    "wasm",
                    policy => policy.WithOrigins([builder.Configuration["BackendUrl"] ?? "https://localhost:7089",
                        builder.Configuration["FrontendUrl"] ?? "https://localhost:7015"])
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(pol => true)
                        .AllowAnyHeader()
                        .AllowCredentials()));

            var app = builder.Build();

            app.AddEndPointsContatos();

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
