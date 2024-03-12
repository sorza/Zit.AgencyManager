using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Request
{
    public record AgenciaRequest([Required] string Descricao, [Required] string CNPJ, [Required] ICollection<Endereco> Enderecos, [Required] ICollection<Contato>? Contatos)
    {
        bool Ativa = true;
    }
}
