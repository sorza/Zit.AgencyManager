namespace Zit.AgencyManager.Web.Request
{
    public record MovimentacaoRequestEdit
    (
        int CaixaId,
        string Tipo,
        decimal Valor,
        string Descricao
    );
}
