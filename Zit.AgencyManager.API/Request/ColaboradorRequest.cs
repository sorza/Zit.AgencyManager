using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Request
{
    public record ColaboradorRequest(
        [Required] string Nome, 
        [Required] string CPF, 
        [Required] string RG, 
        [Required] DateOnly DataNascimento, 
        [Required] int AgenciaId, 
        [Required] int CargoId,
        [Required] DateOnly DataAdmissao,
        [Required] Endereco Endereco,
        ICollection<Contato> Contatos,
        bool Ativo
     );
}
