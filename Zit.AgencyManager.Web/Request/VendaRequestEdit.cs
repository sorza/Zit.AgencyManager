using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.Web.Request
{
    public record VendaRequestEdit
    (
        [Required]
        int EmpresaId,
        [Required]
        decimal Dinheiro,
        [Required]
        decimal Cartao
    );
}
