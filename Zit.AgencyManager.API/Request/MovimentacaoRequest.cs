using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.API.Request
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
