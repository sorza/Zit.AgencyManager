using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Web.Response
{
    public record VendaResponse
    (
        int Id,
        Caixa Caixa,
        EmpresaResponse Empresa,
        decimal Dinheiro,
        decimal Cartao
    );
}
