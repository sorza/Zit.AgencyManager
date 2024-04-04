using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Request
{
    public record AgenciaRequest()
    {
        [Required(ErrorMessage = "A Descrição é obrigatória")]
        [StringLength(150, ErrorMessage = "A descrição pode ter apenas 150 caracteres")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "O CNPJ deve conter 14 dígitos numéricos.")]
        public string? CNPJ { get; set; }

        [Required(ErrorMessage = "É obrigatório informar um endereço")]
        public virtual Endereco? Endereco { get; set; } = new();

        public virtual ICollection<Contato>? Contatos { get; set; } = new List<Contato>();
        public string? Foto { get; set; }
        public bool Ativa { get; set; } = true;
    }
}
