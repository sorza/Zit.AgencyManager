using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.Web.Request
{
    public record MovimentacaoRequest
    (
        [Required]
        int CaixaId,
        [Required]
        string Tipo,
        [Required]
        decimal Valor,
        [Required]
        string Descricao
    );
}
