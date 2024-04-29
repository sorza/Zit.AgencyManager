using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.API.Request;
using Zit.AgencyManager.API.Response;
using Zit.AgencyManager.Dados.Banco;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Endpoints
{
    public static class LocalidadeExtensions
    {
        public static void AddEndpointsLocalidades(this WebApplication app)
        {
            var grouBuilder = app.MapGroup("localidades")
                               .RequireAuthorization()
                                .WithTags("Localidades");

            grouBuilder.MapGet("", ([FromServices] DAL<Localidade> dal) =>
            {
                return Results.Ok(EntityListToResponseList(dal.Listar()));
            });

            grouBuilder.MapGet("busca/{local}", ([FromServices] DAL<Localidade> dal, string local) =>
            {
                return Results.Ok(EntityListToResponseList(dal.Listar().Where(l=> l.Cidade.Contains(local.ToUpper()))));
            });

            grouBuilder.MapGet("{id}", ([FromServices] DAL<Localidade> dal, int id) =>
            {
                var localidade = dal.RecuperarPor(l => l.Id == id);

                if (localidade is null) return Results.NotFound();

                return Results.Ok(EntityToResponse(localidade));
            });

            grouBuilder.MapPost("", ([FromServices] DAL<Localidade> dal, [FromBody] LocalidadeRequest request) =>
            {
                var context = new ValidationContext(request);
                var results = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(request, context, results, true);

                if (!isValid)
                {
                    var errors = results.Select(x => x.ErrorMessage);
                    return Results.BadRequest(errors);
                }

                Localidade localidade = new()
                {
                    Cidade = request.Cidade.ToUpper(),
                    UF = request.UF.ToUpper()
                };

                var localidades = dal.Listar();

                if(localidades.Contains(localidade)) return Results.BadRequest("A localidade já existe na base de dados");

                dal.Adicionar(localidade);

                return Results.Ok();
            });

            grouBuilder.MapPut("{id}", ([FromServices] DAL<Localidade> dal, [FromBody] LocalidadeRequestEdit request, int id) =>
            {
                var context = new ValidationContext(request);
                var results = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(request, context, results, true);

                if (!isValid)
                {
                    var errors = results.Select(x => x.ErrorMessage);
                    return Results.BadRequest(errors);
                }

                var localidade = dal.RecuperarPor(l=> l.Id == id);

                if (localidade is null) return Results.BadRequest();

                var localidades = dal.Listar();

                if (localidades.Contains(localidade)) return Results.BadRequest("Já existe na base de dados uma localidade com essas definições");

                dal.Atualizar(localidade);

                return Results.NoContent();

            });

            grouBuilder.MapDelete("{id}", ([FromServices] DAL<Localidade> dal, int id) =>
            {
                var localidade = dal.RecuperarPor(l => l.Id == id);

                if (localidade is null) return Results.BadRequest();

                dal.Deletar(localidade);

                return Results.NoContent();
            });
        }

        private static ICollection<LocalidadeResponse> EntityListToResponseList(IEnumerable<Localidade> listaDeLocalidades)
        {
            return listaDeLocalidades.Select(a => EntityToResponse(a)).ToList();
        }

        private static LocalidadeResponse EntityToResponse(Localidade localidade)
        {
            return new LocalidadeResponse(localidade.Id, localidade.Cidade, localidade.UF);
        }
    }
}
