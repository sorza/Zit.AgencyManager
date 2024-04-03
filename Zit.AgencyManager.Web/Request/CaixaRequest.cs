using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.Web.Request
{
    public record CaixaRequest
    (
        [Required]
        int ColaboradorId,
        decimal TrocoInicial
    );
}
