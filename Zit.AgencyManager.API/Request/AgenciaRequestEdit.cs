using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Request
{
    public record AgenciaRequestEdit
    (
        [StringLength(150, ErrorMessage = "A descrição pode ter apenas 150 caracteres")]
        string Descricao,

        [RegularExpression(@"^\d{14}$", ErrorMessage = "O CNPJ deve conter 14 dígitos.")]
        string CNPJ, 
        Endereco? Endereco, 
        ICollection<Contato>? Contatos, 
        bool Ativa, 
        string? Foto     
    );
}
