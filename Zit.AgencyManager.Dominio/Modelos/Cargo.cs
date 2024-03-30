namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Atribuicoes { get; set; }
        public decimal Salario { get; set; }
        public int AgenciaId { get; set; }
        public virtual Agencia Agencia { get; set; }

    }
}
