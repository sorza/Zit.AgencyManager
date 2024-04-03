using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Response
{
    public record VendaVirtualResponse
    (
        int Id,
        Caixa Caixa,
        Empresa Empresa,
        Localidade Origem,
        Localidade Destino,
        decimal Valor,
        string FormaPagamento,
        bool Pago,
        Cliente Cliente
    );
}
