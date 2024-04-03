using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Web.Request
{
    public record ClienteRequest([Required] string Nome, ICollection<Contato>? Contatos);
}
