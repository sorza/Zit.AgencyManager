namespace Zit.AgencyManager.Dominio.Modelos
{
    public class ContratoAgenciaEmpresa
    {
        public int Id { get; set; }
        public bool Ativo { get; set; } = true;
        public int AgenciaId { get; set; }
        public virtual Agencia Agencia { get; set; }
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
        public decimal Comissao { get; set; }
        public string ModalidadeComissao { get; set; }
        public string FrequenciaAcerto { get; set; }
        public string ModalidadeAcerto { get; set; }
        public bool EmiteNota { get; set; }
        public DateOnly DataContrato { get; set; }
        public DateOnly? DataDistrato { get; set; }
    }
}