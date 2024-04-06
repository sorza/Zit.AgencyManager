using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Request
{
    public record ColaboradorRequest()
    {
        [Required(ErrorMessage = "O Nome é obrigatório")]
        [StringLength(90, ErrorMessage = "O nome pode ter no máximo 90 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter 11 dígitos numéricos.")]
        public string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "O RG é obrigatório")]
        [StringLength(20, ErrorMessage = "O RG pode ter no máximo 20 dígitos")]
        public string RG { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        public DateOnly DataNascimento { get; set; }
        [Required]
        public int AgenciaId { get; set; }
        [Required]
        public int CargoId { get; set; }

        [Required(ErrorMessage = "A data de admissão é obrigatória")]
        public DateOnly DataAdmissao { get; set; }

        [Required]
        public EnderecoRequest Endereco { get; set; } = new();
        [Required]
        public ICollection<Contato> Contatos { get; set; } = new List<Contato>();
        [Required]
        public int UsuarioId { get; set; }
        public bool Ativo { get; set; }
    }
}
