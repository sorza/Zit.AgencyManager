using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.API.Request;
using Zit.AgencyManager.API.Response;
using Zit.AgencyManager.Dados.Banco;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Endpoints
{
    public static class CaixaExtensions
    {
        public static void AddEndpointsCaixas(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("caixas")
                                    .RequireAuthorization()
                                    .WithTags("Caixas");

            groupBuilder.MapGet("", ([FromServices] DAL<Caixa> dal) =>
            {
                return Results.Ok(EntityListToResponseList(dal.Listar()));
            });

            groupBuilder.MapGet("colaborador/{id}/{mes}-{ano}", ([FromServices] DAL<Caixa> dal, int id, int mes, int ano) =>
            {
                return Results.Ok(EntityListToResponseList(dal.Listar()
                                                .Where(c => c.ColaboradorId == id 
                                                            && c.Data.Month == mes 
                                                            && c.Data.Year == ano))
                                                .OrderByDescending(d => d.Data));
            });

            groupBuilder.MapGet("{id}", ([FromServices] DAL<Caixa> dal, int id) =>
            {                
                var caixa = dal.RecuperarPor(c => c.Id == id);

                if (caixa is null) return Results.NotFound();

                return Results.Ok(EntityToResponse(caixa));

            });

            groupBuilder.MapPost("", ([FromServices] DAL<Caixa> dal, [FromBody] CaixaRequest request) =>
            {
                var context = new ValidationContext(request);
                var results = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(request, context, results, true);

                if (!isValid)
                {
                    var errors = results.Select(x => x.ErrorMessage);
                    return Results.BadRequest(errors);
                }

                var ultimoCaixa = dal.Listar().Where(c => c.ColaboradorId == request.ColaboradorId).Last();

               
                if (ultimoCaixa.Aberto == true) return Results.BadRequest("O usuário já possui um caixa aberto.");

                Caixa caixa = new()
                {
                    Aberto = true,
                    ColaboradorId = request.ColaboradorId,
                    Data = DateTime.Now,
                    TrocoInicial = ultimoCaixa.TrocoFinal
                };

                if (ultimoCaixa is null) caixa.TrocoInicial = 300;

                dal.Adicionar(caixa);                       

                return Results.Ok();

            });

            groupBuilder.MapPut("{id}", ([FromServices]DAL<Caixa> dal, [FromBody] CaixaRequestEdit request, int id) =>
            {                
                var caixa = dal.RecuperarPor(c => c.Id == id);

                if (caixa is null) return Results.NotFound();

                caixa.Aberto = request.Aberto;
                caixa.TrocoFinal = request.TrocoFinal;
                caixa.TrocoInicial = request.TrocoInicial;

                dal.Atualizar(caixa);

                return Results.NoContent();
            });

            groupBuilder.MapDelete("{id}", ([FromServices] DAL<Caixa> dal, int id) =>
            {
                var caixa = dal.RecuperarPor(c => c.Id == id);

                if (caixa is null) return Results.NotFound();

                dal.Deletar(caixa);

                return Results.NoContent();
            });
        }

        private static ICollection<CaixaResponse> EntityListToResponseList(IEnumerable<Caixa> listaDeCaixas)
        {
            return listaDeCaixas.Select(a => EntityToResponse(a)).ToList();
        }

        private static CaixaResponse EntityToResponse(Caixa caixa)
        {
            return new CaixaResponse(caixa.Id, caixa.Colaborador, caixa.Data, caixa.TrocoInicial, caixa.TrocoFinal, caixa.Aberto);
        }
    }
}
