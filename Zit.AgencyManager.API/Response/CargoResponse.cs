using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Response
{
    public record CargoResponse(int Id, string Descricao, string Atribuicoes, decimal Salario, Agencia Agencia);
}
