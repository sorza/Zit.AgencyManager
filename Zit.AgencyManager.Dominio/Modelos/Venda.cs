namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Venda
    {
            public int Id { get; set; }
            public int CaixaId { get; set; }
            public virtual Caixa Caixa { get; set; }
            public int ContratoAgenciaEmpresaId { get; set; }
            public virtual ContratoAgenciaEmpresa ContratoAgenciaEmpresa { get; set; }
            public decimal? Dinheiro { get; set; }
            public decimal? Cartao { get; set; }        
    }
}

