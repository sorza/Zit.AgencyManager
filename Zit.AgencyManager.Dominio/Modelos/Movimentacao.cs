namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public int CaixaId { get; set; }
        public virtual Caixa Caixa { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public string? Descricao { get; set; }
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int? TrajetoId { get; set; }
        public virtual Trajeto? Trajeto { get; set; }
        public string? FormaPagamento { get; set; }
        public bool Pago { get; set; }
    }
}
