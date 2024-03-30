using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Request
{
    public record AgenciaRequest(
        [Required] string Descricao, 
        [Required] string CNPJ, 
        [Required] Endereco Endereco, 
        [Required] ICollection<Contato>? Contatos,
        string? Foto)
    {
        bool Ativa = true;
    }
}
