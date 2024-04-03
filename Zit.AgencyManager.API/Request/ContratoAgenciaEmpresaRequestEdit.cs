namespace Zit.AgencyManager.API.Request
{
    public record ContratoAgenciaEmpresaRequestEdit
    (       
        bool Ativo,
        int AgenciaId,
        int EmpresaId,
        decimal Comissao,
        string ModalidadeComissao,
        string FrequenciaAcerto,
        string ModalidadeAcerto,
        bool EmiteNota,
        DateOnly DataContrato,
        DateOnly? DataDistrato
    );
}
