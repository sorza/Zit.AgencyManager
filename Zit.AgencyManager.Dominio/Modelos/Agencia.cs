using System.Security;

namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Agencia
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public bool Ativa { get; set; } = true;
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();
        public virtual ICollection<ContratoAgenciaEmpresa> Empresas { get; set; } = new List<ContratoAgenciaEmpresa>();
       
    }
}
