namespace Zit.AgencyManager.API.Request
{
    public record CaixaRequestEdit
    (
       decimal TrocoInicial,
       decimal TrocoFinal,
       bool Aberto
   );
}
