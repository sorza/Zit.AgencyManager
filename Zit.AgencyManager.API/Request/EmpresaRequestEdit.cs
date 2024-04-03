using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Request
{
    public record EmpresaRequestEdit(
        string RazaoSocial, 
        string NomeFantasia,
        string CNPJ, 
        Endereco Endereco,
        ICollection<Contato> Contatos
    );
}
