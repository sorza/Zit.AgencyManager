using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.Web.Request
{
    public record CargoRequest(
        [Required] string Descricao,
        [Required] string Atribuicoes,
        [Required] decimal Salario,
        [Required] int AgenciaId);

}
