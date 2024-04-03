namespace Zit.AgencyManager.API.Request
{
    public record MovimentacaoRequestEdit
    (       
        int CaixaId,        
        string Tipo,        
        decimal Valor,       
        string Descricao
    );
}
