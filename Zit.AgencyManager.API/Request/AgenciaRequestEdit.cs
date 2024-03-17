using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Request
{
    public record AgenciaRequestEdit(string Descricao, string CNPJ, Endereco? Endereco, ICollection<Contato>? Contatos, bool Ativa);
}
