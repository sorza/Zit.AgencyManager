using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.Web.Request
{
    public record CaixaRequestEdit
    (
       decimal TrocoInicial,
       decimal TrocoFinal,
       bool Aberto
   );
}
