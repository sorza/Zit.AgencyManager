namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Agencia
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();
        public virtual ICollection<Colaborador> Colaboradores { get; set; } = new List<Colaborador>();
        public virtual ICollection<ContratoAgenciaEmpresa> Empresas { get; set; } = new List<ContratoAgenciaEmpresa>();

        public void AdicionarContato(Contato contato)
        {
            if (contato is not null)
                Contatos.Add(contato);
        }
        public void AdicionarColaborador(Colaborador colaborador)
        {
            if (colaborador is not null)
                Colaboradores.Add(colaborador);
        }
        public void AdicionarEmpresa(ContratoAgenciaEmpresa empresa)
        {
            if (empresa is not null)
                Empresas.Add(empresa);
        }
    }
}
