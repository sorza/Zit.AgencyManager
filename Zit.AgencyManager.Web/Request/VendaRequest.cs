using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.Web.Request
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
