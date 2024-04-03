using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Web.Request
{
    public record ClienteRequestEdit
    (
        string Nome,
        ICollection<Contato> Contatos
    );
}
