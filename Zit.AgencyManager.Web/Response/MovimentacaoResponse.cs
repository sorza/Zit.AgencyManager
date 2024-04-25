using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Web.Response
{
    public record MovimentacaoResponse()
    { 
        public int Id { get; set; }
        public CaixaResponse Caixa { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
    }
}
