using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Response
{
    public record AgenciaResponse
     (      
        int Id,
        string Descricao,      
        string CNPJ,
        Endereco Endereco,
        ICollection<Contato> Contatos
     );
}
