using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Response
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
