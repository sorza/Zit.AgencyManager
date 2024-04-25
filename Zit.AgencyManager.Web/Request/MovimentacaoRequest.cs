using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.Web.Request
{
    public record MovimentacaoRequest()
    {
        [Required(ErrorMessage ="O caixa é obrigatório")]
        public int CaixaId { get; set; }

        [Required(ErrorMessage ="É obrigatório informar o tipo de movimentação")]
        public string Tipo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O valor é obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A descrição do lançamento é obrigatória")]
        public string Descricao { get; set; } = string.Empty;
    }
}
