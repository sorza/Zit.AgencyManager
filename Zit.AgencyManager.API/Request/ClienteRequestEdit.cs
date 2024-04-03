using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Request
{
    public record ClienteRequestEdit
    (
        string Nome,
        ICollection<Contato> Contatos
    );
}
