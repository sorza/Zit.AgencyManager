using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.Web.Request
{
    public record LocalidadeRequestEdit
    (
        string Cidade,
        string UF
    );
}
