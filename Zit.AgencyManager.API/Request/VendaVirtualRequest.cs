using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.API.Request
{
    public record VendaVirtualRequest
    (
        [Required]
        int CaixaId,
        [Required]
        int EmpresaId,
        [Required]
        int OrigemId,
        [Required]
        int DestinoId,
        [Required]
        decimal Valor,
        [Required]
        string FormaPagamento,
        [Required]
        bool Pago,
        [Required]
        int ClienteId
    );
}
