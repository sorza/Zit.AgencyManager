using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Web.Response
{
    public record VendaResponse
    (
        int Id,
        Caixa Caixa,
        Empresa Empresa,
        decimal Dinheiro,
        decimal Cartao
    );
}
