using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Web.Response
{
    public record VendaVirtualResponse
    (
        int Id,
        Caixa Caixa,
        EmpresaResponse Empresa,
        LocalidadeResponse Origem,
        LocalidadeResponse Destino,
        decimal Valor,
        string FormaPagamento,
        string? Observacao
    );
}
