using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Web.Response
{
    public record CaixaResponse
    (
        int Id,
        Colaborador Colaborador,
        DateTime Data,
        decimal TrocoInicial,
        decimal TrocoFinal,
        bool Aberto
    );
}
