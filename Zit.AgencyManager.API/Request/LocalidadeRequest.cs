using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.API.Request
{
    public record LocalidadeRequest
    (
        [Required]
        string Cidade,
        [Required]
        string UF
    );
}
