using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Response
{
    public record AgenciaResponse
     (      
        int id,
        string Descricao,      
        string CNPJ,
        ICollection<Endereco> Enderecos,
        ICollection<Contato> Contatos
     );
}
