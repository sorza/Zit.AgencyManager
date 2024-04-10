using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Request
{
    public record ContratoAgenciaEmpresaRequest()
    {
        [Required(ErrorMessage = "É obrigatório informar uma agência.")]
        public int AgenciaId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar uma empresa.")]
        public int EmpresaId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a comissão.")]
        public decimal Comissao { get; set; }

        [Required(ErrorMessage = "É obrigatório informar em que período a comissão é recebida.")]
        public string ModalidadeComissao { get; set; } = string.Empty;

        [Required(ErrorMessage = "É obrigatório informar a frequência do acerto.")]
        public string FrequenciaAcerto { get; set; } = string.Empty;

        [Required(ErrorMessage = "É obrigatório informar a peridiocidade do acerto.")]
        public string ModalidadeAcerto { get; set; } = string.Empty;
        public bool EmiteNota { get; set; }
        [Required(ErrorMessage = "É obrigatório informar a data do contrato.")]
        public DateOnly DataContrato { get; set; }
    }
}
