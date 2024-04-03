using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.Web.Request
{
    public record CargoRequestEdit(string Descricao, string Atribuicoes, decimal Salario);
}
