namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Caixa
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public virtual Colaborador Colaborador { get; set; }
        public DateTime Data { get; set; }
        public decimal TrocoInicial { get; set; }
        public decimal TrocoFinal { get; set; }
        public bool Aberto { get; set; }
    }
}
