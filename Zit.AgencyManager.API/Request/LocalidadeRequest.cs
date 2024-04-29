using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.API.Request
{
    public record LocalidadeRequest()
    {
        [Required(ErrorMessage = "Informe o a cidade")]
        [StringLength(90, ErrorMessage = "O campo pode ter no máximo 90 caracteres")]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o Estado (UF)")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "A UF deve conter 2 caracteres")]
        [RegularExpression("^[A-Z]+$", ErrorMessage = "O campo deve ser alfabético")]
        public string UF { get; set; } = string.Empty;
    }
}
