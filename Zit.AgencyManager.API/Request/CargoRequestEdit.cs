using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.API.Request
{
    public record CargoRequestEdit([Required] string Descricao, [Required] string Atribuicoes, [Required] decimal Salario)
        : CargoRequest(Descricao, Atribuicoes, Salario);
}
