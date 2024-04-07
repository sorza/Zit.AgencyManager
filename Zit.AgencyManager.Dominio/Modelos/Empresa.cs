namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Empresa
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string? NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public string? Logo { get; set; }
        public virtual ICollection<Contato>? Contatos { get; set; } = new List<Contato>();

    }
}
