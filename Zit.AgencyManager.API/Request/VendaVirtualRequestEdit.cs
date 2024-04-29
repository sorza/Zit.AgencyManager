using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.API.Request
{
    public record VendaVirtualRequestEdit
    (       
        int CaixaId,       
        int EmpresaId,       
        int OrigemId,       
        int DestinoId,        
        decimal Valor,       
        string FormaPagamento,
        string Observacao
     );
}
