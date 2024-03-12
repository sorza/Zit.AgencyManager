namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Endereco
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string? Complemento { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;

            var endereco = (Endereco)obj;

            if( endereco.CEP == CEP &&
                endereco.Logradouro == Logradouro &&
                endereco.Numero == Numero &&
                endereco.Bairro == Bairro &&
                endereco.Cidade == Cidade &&
                endereco.Uf == Uf &&
                endereco.Complemento == Complemento) return true;

            return false;
        }
    }    
}
