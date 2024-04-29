using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.Web.Request
{
    public record VendaVirtualRequest()
    {
        [Required]
        public int CaixaId { get; set; }

        [Required]
        public int EmpresaId { get; set; }

        [Required]
        public int OrigemId { get; set; }

        [Required]
        public int DestinoId { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public string FormaPagamento { get; set; } = string.Empty;
        public string? Observacao { get; set; }
    }
}
