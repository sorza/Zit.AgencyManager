using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Request
{
    public record ContratoAgenciaEmpresaRequest(   
        int AgenciaId,
        int EmpresaId, 
        decimal Comissao,
        string ModalidadeComissao,
        string FrequenciaAcerto,
        string ModalidadeAcerto,
        bool EmiteNota,
        DateOnly DataContrato
    );
}
