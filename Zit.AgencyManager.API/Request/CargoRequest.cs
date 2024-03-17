using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.API.Request
{
    public record CargoRequest(
        [Required] string Descricao, 
        [Required] string Atribuicoes, 
        [Required] decimal Salario);

}
