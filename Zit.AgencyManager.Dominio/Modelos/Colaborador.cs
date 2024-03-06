namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateOnly DataNascimento { get; set; }
        public int AgenciaId { get; set; }
        public virtual Agencia Agencia { get; set; }
        public int CargoId { get; set; }
        public virtual Cargo Cargo { get; set; }
        public DateOnly DataAdmissao { get; set; }
        public DateOnly? DataDemissao { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
        public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();

        public void AdicionarEndereco(Endereco endereco)
        {
            if(endereco is not null)
                Enderecos.Add(endereco);                        
        }

        public void AdicionarContato(Contato contato)
        {
            if(contato is not null)
                Contatos.Add(contato);
        }
    }
}
