using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

            groupBuilder.MapGet("{id}", ([FromServices] DAL<VendaVirtual> dal, int id) =>
            {
                var venda = dal.RecuperarPor(v => v.Id == id);

                if (venda is null) return Results.NotFound();

                return Results.Ok(EntityToResponse(venda));
            });

            groupBuilder.MapPost("", ([FromServices] DAL<VendaVirtual> dal, [FromBody] VendaVirtualRequest request) =>
            {               
                VendaVirtual venda = new()
                {
                    CaixaId = request.CaixaId,                    
                    EmpresaId = request.EmpresaId,
                    OrigemId = request.OrigemId,
                    DestinoId = request.DestinoId,
                    Valor = request.Valor,
                    FormaPagamento = request.FormaPagamento,
                    Pago = request.Pago,
                    ClienteId = request.ClienteId                    
                };

                dal.Adicionar(venda);

                return Results.Ok();
            });

            groupBuilder.MapPut("{id}", ([FromServices] DAL<VendaVirtual> dal, [FromBody]VendaVirtualRequestEdit request, int id) =>
            {              
                var venda = dal.RecuperarPor(v => v.Id == id);

                if (venda is null) return Results.NotFound();

                if(request.CaixaId > 0) venda.CaixaId = request.CaixaId;
                if(request.EmpresaId > 0) venda.EmpresaId = request.EmpresaId;
                if(request.OrigemId > 0) venda.OrigemId = request.OrigemId;
                if(request.DestinoId > 0) venda.DestinoId = request.DestinoId;
                if(request.Valor > 0) venda.Valor = request.Valor;
                venda.Pago = request.Pago;
                if(!request.FormaPagamento.IsNullOrEmpty()) venda.FormaPagamento = request.FormaPagamento;
                if(request.ClienteId > 0) venda.ClienteId = request.ClienteId;

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
            return new VendaVirtualResponse(vendaVirtual.Id, vendaVirtual.Caixa, vendaVirtual.Empresa, vendaVirtual.Origem, vendaVirtual.Destino, vendaVirtual.Valor, vendaVirtual.FormaPagamento, vendaVirtual.Pago, vendaVirtual.Cliente);
        }
    }
}
