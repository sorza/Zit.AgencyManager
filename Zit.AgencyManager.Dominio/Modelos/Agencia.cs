using System.Security;

namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Agencia
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public bool Ativa { get; set; } = true;
        public virtual ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
        public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();
        public virtual ICollection<ContratoAgenciaEmpresa> Empresas { get; set; } = new List<ContratoAgenciaEmpresa>();       
    }
}
