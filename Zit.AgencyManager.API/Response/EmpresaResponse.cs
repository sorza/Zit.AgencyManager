using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Response
{
    public record EmpresaResponse(
        int Id,
        string RazaoSocial,
        string NomeFantasia,
        string CNPJ,
        Endereco Endereco,
        ICollection<Contato> Contato,
        string? Logo);
}
