using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Web.Response
{
    public record CaixaResponse()
    {
        public int Id { get; set; }
        public Colaborador Colaborador { get; set; } = new Colaborador();
        public DateTime Data { get; set; }
        public decimal TrocoInicial { get; set; }
        public decimal TrocoFinal { get; set; }
        public bool Aberto { get; set; }
    }
}
