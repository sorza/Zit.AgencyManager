using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.Web.Request
{
    public record VendaRequest()
    {
        [Required(ErrorMessage = "É obrigatório informar uma caixa")]
        public int CaixaId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar uma empresa")]
        public int EmpresaId { get; set; }
       
        [Required(ErrorMessage = "É obrigatório informar um valor em dinheiro")]
        public decimal Dinheiro { get; set; }
       
        [Required(ErrorMessage = "É obrigatório informar um valor em cartão")]
        public decimal Cartao { get; set; }
    }
}
