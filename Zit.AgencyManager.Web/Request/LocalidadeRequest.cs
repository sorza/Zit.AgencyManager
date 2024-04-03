using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.Web.Request
{
    public record LocalidadeRequest
    (
        [Required]
        string Cidade,
        [Required]
        string UF
    );
}
