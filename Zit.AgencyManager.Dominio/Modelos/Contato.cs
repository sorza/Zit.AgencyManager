namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Contato
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string Complemento { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var contato = (Contato)obj;

            return Tipo == contato.Tipo &&
                   Descricao == contato.Descricao &&
                   Complemento == contato.Complemento;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Tipo, Descricao, Complemento);
        }
    }
 }
