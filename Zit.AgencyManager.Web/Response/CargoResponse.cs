using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Web.Response
{
    public record CargoResponse(int Id, string Descricao, string Atribuicoes, decimal Salario, Agencia Agencia);
}
