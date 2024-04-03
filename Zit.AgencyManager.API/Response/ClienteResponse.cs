using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Response
{
    public record ClienteResponse
        (
            int Id,
            string Nome,
            ICollection<Contato> Contatos
        );
}
