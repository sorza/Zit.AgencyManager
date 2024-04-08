using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Request
{
    public record EmpresaRequest()
    {
        [Required(ErrorMessage = "A Razão Social é obrigatória")]
        [StringLength(150, ErrorMessage = "O campo pode ter no máximo 150 caracteres")]
        public string RazaoSocial { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Nome Fantasia obrigatório")]
        [StringLength(150, ErrorMessage = "O campo pode ter no máximo 150 caracteres")]
        public string NomeFantasia { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "O CNPJ deve conter 14 dígitos numéricos.")]
        public string CNPJ { get; set; } = string.Empty;

        [Required(ErrorMessage = "É obrigatório informar um endereço")]
        public EnderecoRequest Endereco { get; set; } = new();
        public virtual ICollection<Contato>? Contatos { get; set; } = new List<Contato>();
        public string? Logo { get; set; }
    }
}
