using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.API.Request
{
    public record CargoRequestEdit(string Descricao, string Atribuicoes, decimal Salario);
}
