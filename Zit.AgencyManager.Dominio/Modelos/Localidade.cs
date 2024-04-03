namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Localidade
    {
        public int Id { get; set; }
        public string Cidade {  get; set; }
        public string UF { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var localidade = (Localidade)obj;

            return Cidade == localidade.Cidade &&
                   UF == localidade.UF;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Cidade, UF);
        }
    }   
}
