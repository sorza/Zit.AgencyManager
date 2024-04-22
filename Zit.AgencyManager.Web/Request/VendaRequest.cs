using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.Web.Request
{
    public record VendaRequest()
    {
        [Required]
        public int CaixaId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar uma empresa")]
        public int EmpresaId { get; set; }
       
        public decimal Dinheiro { get; set; }
       
        public decimal Cartao { get; set; }
    }
}
