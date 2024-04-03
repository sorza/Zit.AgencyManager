using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.API.Request
{
    public record VendaRequest
    (
        [Required]
        int CaixaId,
        [Required]
        int EmpresaId,
        [Required]
        decimal Dinheiro,
        [Required]
        decimal Cartao
    );
}
