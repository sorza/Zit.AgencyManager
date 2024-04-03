using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Response
{
    public record CaixaResponse
    (
        Colaborador Colaborador,
        DateTime Data,
        decimal TrocoInicial,
        decimal TrocoFinal,
        bool Aberto
    );
}
