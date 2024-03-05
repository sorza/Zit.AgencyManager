namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Trajeto
    {
        public int Id { get; set; }
        public int OrigemId { get; set; }
        public virtual Localidade Origem { get; set; }
        public int DestinoId { get; set; }
        public virtual Localidade Destino { get; set; }
    }
}
