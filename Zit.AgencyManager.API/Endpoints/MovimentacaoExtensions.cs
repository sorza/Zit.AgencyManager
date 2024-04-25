using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Zit.AgencyManager.API.Request;
using Zit.AgencyManager.API.Response;
using Zit.AgencyManager.Dados.Banco;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Endpoints
{
    public static class MovimentacaoExtensions
    {
        public static void AddEndpointsMovimentacoes(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("movimentacoes")
                                   .RequireAuthorization()
                                    .WithTags("Movimentações");

            groupBuilder.MapGet("", ([FromServices]DAL<Movimentacao> dal) =>
            {
                return Results.Ok(EntityListToResponseList(dal.Listar()));
            });

            groupBuilder.MapGet("caixa/{id}", ([FromServices] DAL<Movimentacao> dal, int id) =>
            {
                return Results.Ok(EntityListToResponseList(dal.Listar().Where(m => m.CaixaId == id)));
            });

            groupBuilder.MapGet("{id}", ([FromServices] DAL<Movimentacao> dal, int id) =>
            {
                var movimentacao = dal.RecuperarPor(m=>m.Id == id);

                if (movimentacao is null) return Results.NotFound();

                return Results.Ok(EntityToResponse(movimentacao));
            });

            groupBuilder.MapPost("", ([FromServices] DAL<Movimentacao> dal,[FromBody]MovimentacaoRequest request) =>
            {
                Movimentacao movimentacao = new()
                {
                    CaixaId = request.CaixaId,
                    Tipo = request.Tipo,
                    Valor = request.Valor,
                    Descricao = request.Descricao
                };

                dal.Adicionar(movimentacao);

                return Results.Ok();
            });

            groupBuilder.MapPut("{id}", ([FromServices] DAL<Movimentacao> dal, [FromBody]MovimentacaoRequestEdit request, int id) =>
            {
                var movimentacao = dal.RecuperarPor(m => m.Id == id);

                if (movimentacao is null) return Results.NotFound();

                if(request.CaixaId > 0) movimentacao.CaixaId = request.CaixaId;
                if(!request.Tipo.IsNullOrEmpty()) movimentacao.Tipo = request.Tipo;
                if(request.Valor > 0) movimentacao.Valor = request.Valor;
                if(!request.Descricao.IsNullOrEmpty()) movimentacao.Descricao = request.Descricao;

                dal.Atualizar(movimentacao);

                return Results.NoContent();

            });

            groupBuilder.MapDelete("{id}", ([FromServices] DAL<Movimentacao> dal, int id) =>
            {
                var movimentacao = dal.RecuperarPor(m => m.Id == id);

                if (movimentacao is null) return Results.NotFound();

                dal.Deletar(movimentacao);

                return Results.NoContent();
            });
        }

        private static MovimentacaoResponse EntityToResponse(Movimentacao movimentacao)
        {
            return new MovimentacaoResponse(movimentacao.Id, movimentacao.Caixa, movimentacao.Tipo, movimentacao.Valor, movimentacao.Descricao!);
        }

        private static IEnumerable<MovimentacaoResponse> EntityListToResponseList(IEnumerable<Movimentacao> movimentacoes)
        {
            return movimentacoes.Select( m => EntityToResponse(m)).ToList();
        }
    }
}
