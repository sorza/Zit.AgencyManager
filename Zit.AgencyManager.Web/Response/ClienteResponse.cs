using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Web.Response
{
    public record ClienteResponse
        (
            int Id,
            string Nome,
            ICollection<Contato> Contatos
        );
}
