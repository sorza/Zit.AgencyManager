using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.Web.Request
{
    public record VendaVirtualRequestEdit
    (
        int CaixaId,
        int EmpresaId,
        int OrigemId,
        int DestinoId,
        decimal Valor,
        string FormaPagamento,
        string? Observacao
     );
}
