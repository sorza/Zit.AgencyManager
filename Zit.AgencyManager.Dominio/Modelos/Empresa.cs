namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Empresa
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; } = new();
        public string? Logo { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();

    }
}
