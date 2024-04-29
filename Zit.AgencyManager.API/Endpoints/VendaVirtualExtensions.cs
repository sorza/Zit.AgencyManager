using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.API.Request;
using Zit.AgencyManager.API.Response;
using Zit.AgencyManager.Dados.Banco;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Endpoints
{
    public static class VendaVirtualExtensions
    {
        public static void AddEndpointsVendasVirtuais(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("vendasvirtuais")
                                    .RequireAuthorization()
                                    .WithTags("Vendas Virtuais");

            groupBuilder.MapGet("", ([FromServices] DAL<VendaVirtual> dal) =>
            {
                return Results.Ok(EntityListToResponseList(dal.Listar()));
            });

            groupBuilder.MapGet("caixa/{caixaId}", ([FromServices] DAL<VendaVirtual> dal, int caixaId) =>
            {
                return Results.Ok(EntityListToResponseList(dal.Listar().Where(v=>v.CaixaId == caixaId)));
            });

            groupBuilder.MapGet("{id}", ([FromServices] DAL<VendaVirtual> dal, int id) =>
            {
                var venda = dal.RecuperarPor(v => v.Id == id);

                if (venda is null) return Results.NotFound();

                return Results.Ok(EntityToResponse(venda));
            });

            groupBuilder.MapPost("", ([FromServices] DAL<VendaVirtual> dal, [FromBody] VendaVirtualRequest request) =>
            {
                var context = new ValidationContext(request);
                var results = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(request, context, results, true);

                if (!isValid)
                {
                    var errors = results.Select(x => x.ErrorMessage);
                    return Results.BadRequest(errors);
                }

                VendaVirtual venda = new()
                {
                    CaixaId = request.CaixaId,                    
                    EmpresaId = request.EmpresaId,
                    OrigemId = request.OrigemId,
                    DestinoId = request.DestinoId,
                    Valor = request.Valor,
                    FormaPagamento = request.FormaPagamento,
                    Observacao = request.Observacao
                };

                dal.Adicionar(venda);

                return Results.Ok();
            });

            groupBuilder.MapPut("{id}", ([FromServices] DAL<VendaVirtual> dal, [FromBody]VendaVirtualRequestEdit request, int id) =>
            {              
                var venda = dal.RecuperarPor(v => v.Id == id);

                if (venda is null) return Results.NotFound();

                var context = new ValidationContext(request);
                var results = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(request, context, results, true);

                if (!isValid)
                {
                    var errors = results.Select(x => x.ErrorMessage);
                    return Results.BadRequest(errors);
                }

                venda.CaixaId = request.CaixaId;
                venda.EmpresaId = request.EmpresaId;
                venda.OrigemId = request.OrigemId;
                venda.DestinoId = request.DestinoId;
                venda.Valor = request.Valor;               
                venda.FormaPagamento = request.FormaPagamento;
                venda.Observacao = request.Observacao;

                dal.Atualizar(venda);

                return Results.NoContent();
            });

            groupBuilder.MapDelete("{id}", ([FromServices] DAL<VendaVirtual> dal, int id) =>
            {
                var venda = dal.RecuperarPor(v => v.Id == id);

                if (venda is null) return Results.NotFound();

                dal.Deletar(venda);

                return Results.NoContent();

            });
        }

        private static IEnumerable<VendaVirtualResponse> EntityListToResponseList(IEnumerable<VendaVirtual> listaDeVendas)
        {
            return listaDeVendas.Select(a => EntityToResponse(a)).ToList();
        }

        private static VendaVirtualResponse EntityToResponse(VendaVirtual vendaVirtual)
        {
            return new VendaVirtualResponse(vendaVirtual.Id, 
                                            vendaVirtual.Caixa, 
                                            new(vendaVirtual.EmpresaId, 
                                                vendaVirtual.Empresa.RazaoSocial, 
                                                vendaVirtual.Empresa.NomeFantasia, 
                                                vendaVirtual.Empresa.CNPJ,                                                 
                                                vendaVirtual.Empresa.Endereco, 
                                                vendaVirtual.Empresa.Contatos, 
                                                vendaVirtual.Empresa.Logo), 
                                            new(vendaVirtual.OrigemId, vendaVirtual.Origem.Cidade, vendaVirtual.Origem.UF),
                                            new(vendaVirtual.DestinoId, vendaVirtual.Destino.Cidade, vendaVirtual.Destino.UF),
                                            vendaVirtual.Valor, 
                                            vendaVirtual.FormaPagamento,
                                            vendaVirtual.Observacao!);
        }
    }
}
