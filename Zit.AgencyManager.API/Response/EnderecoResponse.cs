namespace Zit.AgencyManager.API.Response
{
    public record EnderecoResponse(
         int Id,
         string CEP,
         string Logradouro,
         string Numero,
         string Bairro,
         string Localidade,
         string Uf,
         string? Complemento
     );
}
