using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Request
{
    public record AgenciaRequestEdit(string Descricao, string CNPJ, Endereco Endereco, List<Contato> Contatos, bool Ativa) 
        : AgenciaRequest (Descricao, CNPJ, Endereco, Contatos);
}
