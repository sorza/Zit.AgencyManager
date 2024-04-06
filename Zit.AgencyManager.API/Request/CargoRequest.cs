using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.API.Request
{    public record CargoRequest()
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A Descrição/Título do cargo é obrigatória.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "As atribuições do cargo são obrigatórias.")]
        public string Atribuicoes { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo salário é obrigatório.")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a agência que o cargo pertence")]
        public int AgenciaId { get; set; }
    }

}
