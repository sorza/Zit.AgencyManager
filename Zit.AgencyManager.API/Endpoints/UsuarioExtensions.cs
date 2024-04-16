using Microsoft.AspNetCore.Mvc;
using Zit.AgencyManager.Dados.Banco;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Endpoints
{
    public static class UsuarioExtensions
    {
        public static void AddEndpointsUsuario(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("usuarios")
                                    .RequireAuthorization()
                                    .WithTags("Usuários");

            groupBuilder.MapGet("{user}", ([FromServices]DAL<Usuario> dal, string user) =>
            {
                if (user is null) return Results.BadRequest();

                var usuario = dal.RecuperarPor(u => u.UserName!.Equals(user));
                
                if(usuario is null) return Results.NotFound();

                return Results.Ok(usuario.Id);
                
            });
        }
    }
}
