using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Zit.AgencyManager.API.Request;
using Zit.AgencyManager.API.Response;
using Zit.AgencyManager.Dados.Banco;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Endpoints
{
    public static class CargoExtensions
    {
        public static void AddEndPointsCargos(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("cargos")
                .WithTags("Cargos");

            groupBuilder.MapGet("", ([FromServices] DAL<Cargo> dal) =>
            {
                var listaDeCargos = dal.Listar();
                if (listaDeCargos is null)
                {
                    return Results.NotFound();
                }
                var listaDeCargosResponse = EntityListToResponseList(listaDeCargos);
                return Results.Ok(listaDeCargosResponse);
            });

            groupBuilder.MapGet("{id}", ([FromServices] DAL<Cargo> dal, int id) =>
            {
                var cargo = dal.RecuperarPor(a => a.Id.Equals(id));

                if (cargo is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(EntityToResponse(cargo));

            });

            groupBuilder.MapPost("", ([FromServices] DAL<Cargo> dal, CargoRequest request ) =>
            {
                if (request is null) return Results.BadRequest();

                var cargo = new Cargo()
                {
                    Atribuicoes = request.Atribuicoes,
                    Descricao = request.Descricao,
                    Salario = request.Salario
                };
                            
                dal.Adicionar(cargo);

                return Results.Ok();
            });

            groupBuilder.MapPut("{id}", ([FromServices] DAL<Cargo> dal, CargoRequestEdit request, int id ) =>
            {
                if ( request is null) return Results.BadRequest();

                var cargo = dal.RecuperarPor(c => c.Id ==  id);

                if (cargo is null) return Results.NotFound();

                if (!request.Atribuicoes.IsNullOrEmpty()
                    && !request.Atribuicoes.Equals(cargo.Atribuicoes)) cargo.Atribuicoes = request.Atribuicoes;

                if (!request.Descricao.IsNullOrEmpty()
                    && !request.Descricao.Equals(cargo.Descricao)) cargo.Descricao = request.Descricao;

                if (request.Salario > 0
                    && request.Salario != cargo.Salario) cargo.Salario = request.Salario;

                dal.Atualizar(cargo);

                return Results.NoContent();
            });

            groupBuilder.MapDelete("{id}", ([FromServices] DAL<Cargo> dal, int id) =>
            {
                var cargo = dal.RecuperarPor(a => a.Id.Equals(id));

                if (cargo is null)
                {
                    return Results.NotFound();
                }

                dal.Deletar(cargo);

                return Results.NoContent();
            });

        }

        private static ICollection<CargoResponse> EntityListToResponseList(IEnumerable<Cargo> listaDeCargos)
        {
            return listaDeCargos.Select(a => EntityToResponse(a)).ToList();
        }

        private static CargoResponse EntityToResponse(Cargo cargo)
        {
            return new CargoResponse(cargo.Id, cargo.Descricao, cargo.Atribuicoes, cargo.Salario);
        }
    }
}
