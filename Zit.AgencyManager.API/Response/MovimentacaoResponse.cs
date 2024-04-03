using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Response
{
    public record MovimentacaoResponse
    (
        int Id,
        Caixa Caixa,
        string Tipo,
        decimal Valor,
        string Descricao
    );
}
