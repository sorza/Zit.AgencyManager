using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.API.Request
{
    public record CargoRequestEdit
    (
        [Required(ErrorMessage = "A Descrição/Título do cargo é obrigatória.")]
        string Descricao,

        [Required(ErrorMessage = "As atribuições do cargo são obrigatórias.")]
        string Atribuicoes,

        [Required(ErrorMessage = "O campo salário é obrigatório.")]
        decimal Salario
    );
}
