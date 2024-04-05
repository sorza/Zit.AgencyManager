using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.API.Request
{
    public record EnderecoRequest()
    {
        [Required(ErrorMessage = "O CEP é obrigatório")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "O CEP deve conter 8 dígitos numéricos.")]
        public string CEP { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Logradouro é obrigatório")]
        [MaxLength(90, ErrorMessage ="O campo não pode ter mais de 90 caracteres")]
        public string Logradouro { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo número é obrigatório")]
        [RegularExpression(@"^\d+$", ErrorMessage = "O campo deve ser numérico.")]
        [MaxLength(6, ErrorMessage = "O campo pode ter no máximo 6 caracteres.")]
        public string Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo bairro é obrigatório")]
        [MaxLength(90, ErrorMessage = "O campo não pode ter mais de 90 caracteres")]
        public string Bairro { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo cidade é obrigatório")]
        [MaxLength(90, ErrorMessage = "O campo não pode ter mais de 90 caracteres")]
        public string Localidade { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "O UF é obrigatório")]
        [RegularExpression(@"^[a-zA-Z]{2}$", ErrorMessage = "O campo UF deve conter 2 caracteres alfabéticos.")]
        public string UF { get; set; } = string.Empty;

        [MaxLength(90, ErrorMessage = "O campo não pode ter mais de 90 caracteres")]
        public string? Complemento { get; set; }
    }
}

