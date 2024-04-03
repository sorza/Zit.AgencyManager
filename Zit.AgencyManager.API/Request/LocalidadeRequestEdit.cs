using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.API.Request
{
    public record LocalidadeRequestEdit
    (       
        string Cidade,       
        string UF
    );
}
