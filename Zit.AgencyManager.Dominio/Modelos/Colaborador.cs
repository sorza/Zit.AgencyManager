namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Colaborador
    {
        public int Id { get; set; }
        public bool Ativo { get; set; } = true;
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateOnly DataNascimento { get; set; } = new DateOnly();
        public int AgenciaId { get; set; }
        public virtual Agencia Agencia { get; set; }
        public int CargoId { get; set; }
        public virtual Cargo Cargo { get; set; }
        public DateOnly DataAdmissao { get; set; } = new DateOnly();
        public DateOnly DataDemissao { get; set; } = new DateOnly();
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();
      
    }
}
