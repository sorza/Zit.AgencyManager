using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Response
{
    public record AgenciaResponse
     (      
        int id,
        string Descricao,      
        string CNPJ,
        Endereco Endereco,
        ICollection<Contato> Contatos
     );
}
