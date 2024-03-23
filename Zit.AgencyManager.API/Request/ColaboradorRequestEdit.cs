using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Request
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
        int UsuarioId,
        bool Ativo
     );
}
