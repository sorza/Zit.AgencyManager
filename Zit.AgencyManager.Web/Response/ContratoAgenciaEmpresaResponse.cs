using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Web.Response
{
    public record ContratoAgenciaEmpresaResponse
    (
        int Id,
        bool Ativo,
        Agencia Agencia,
        Empresa Empresa,
        decimal Comissao,
        string ModalidadeComissao,
        string FrequenciaAcerto,
        string ModalidadeAcerto,
        bool EmiteNota,
        DateOnly DataContrato,
        DateOnly? DataDistrato
    );
}
