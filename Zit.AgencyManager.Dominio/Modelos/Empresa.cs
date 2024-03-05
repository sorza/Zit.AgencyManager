namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Empresa
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string? NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public decimal Comissao { get; set; }
        public DateOnly? DataContrato { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Contato>? Contatos { get; set; } = new List<Contato>();
        public virtual ICollection<Trajeto>? Trajetos { get; set; } = new List<Trajeto>();

        public void AdicionarContato(Contato contato)
        {
            if (contato is not null) Contatos?.Add(contato);
        }

        public void AdicionarTrajeto(Trajeto trajeto)
        {
            if (trajeto is not null) Trajetos?.Add(trajeto);
        }
    }
}
