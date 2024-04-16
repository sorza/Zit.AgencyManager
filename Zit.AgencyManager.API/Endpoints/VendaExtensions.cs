using Microsoft.AspNetCore.Mvc;
using Zit.AgencyManager.API.Request;
using Zit.AgencyManager.API.Response;
using Zit.AgencyManager.Dados.Banco;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Endpoints
{
    public static class VendaExtensions
    {
        public static void AddEndpointsVendas(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("vendas")
                                .RequireAuthorization()
                                .WithTags("Vendas");

            groupBuilder.MapGet("", ([FromServices] DAL<Venda> dal) =>
            {
                return Results.Ok(EntityListToResponseList(dal.Listar()));
            });

            groupBuilder.MapGet("{id}", ([FromServices] DAL<Venda> dal, int id) =>
            {
                var venda = dal.RecuperarPor(v => v.Id == id);

                if (venda is null) return Results.NotFound();

                return Results.Ok(EntityToResponse(venda));
            });

            groupBuilder.MapPost("", ([FromServices] DAL<Venda> dal, [FromBody] VendaRequest request) =>
            {
                Venda venda = new()
                {
                    CaixaId = request.CaixaId,
                    EmpresaId = request.EmpresaId,
                    Dinheiro = request.Dinheiro,
                    Cartao = request.Cartao                    
                };

                dal.Adicionar(venda);

                return Results.Ok();

            });

            groupBuilder.MapPut("{id}", ([FromServices] DAL<Venda> dal, [FromBody] VendaRequestEdit request, int id) =>
            {              
                var venda = dal.RecuperarPor(v => v.Id==id);

                if(venda is null) return Results.NotFound();

                venda.EmpresaId = request.EmpresaId;
                venda.Dinheiro = request.Dinheiro;
                venda.Cartao = request.Cartao;

                dal.Atualizar(venda);

                return Results.NoContent();

            });

            groupBuilder.MapDelete("{id}", ([FromServices] DAL<Venda> dal, int id) =>
            {
                var venda = dal.RecuperarPor(v => v.Id == id);

                if (venda is null) return Results.NotFound();

                dal.Deletar(venda);

                return Results.NoContent();
            });
        }

        private static IEnumerable<VendaResponse> EntityListToResponseList(IEnumerable<Venda> listaDeVendas)
        {
            return listaDeVendas.Select(a => EntityToResponse(a)).ToList();
        }

        private static VendaResponse EntityToResponse(Venda venda)
        {
            return new VendaResponse(venda.Id, venda.Caixa, venda.Empresa, venda.Dinheiro, venda.Cartao);
        }
    }
}
