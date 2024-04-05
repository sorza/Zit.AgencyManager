using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Web.Response
{
    public record AgenciaResponse
     (
        int Id,
        string Descricao,
        string CNPJ,
        bool Ativa,
        EnderecoResponse Endereco,
        ICollection<Contato> Contatos,
        string? Foto
     );
}
