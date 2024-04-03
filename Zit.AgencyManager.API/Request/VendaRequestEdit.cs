using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.API.Request
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
