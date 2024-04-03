using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Web.Request
{
    public record ColaboradorRequestEdit(
        string Nome,
        string CPF,
        string RG,
        DateOnly DataNascimento,
        int AgenciaId,
        int CargoId,
        DateOnly DataAdmissao,
        DateOnly DataDemissao,
        Endereco Endereco,
        ICollection<Contato>? Contatos,
        bool Ativo
     );
}
