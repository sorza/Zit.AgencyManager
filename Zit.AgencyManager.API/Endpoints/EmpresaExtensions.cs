using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Zit.AgencyManager.API.Request;
using Zit.AgencyManager.API.Response;
using Zit.AgencyManager.Dados.Banco;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Endpoints
{
    public static class EmpresaExtensions
    {
        public static void AddEndpointsEmpresas(this WebApplication app)
        {
            var groubuilder = app.MapGroup("empresas")
                .WithTags("Empresas");

            groubuilder.MapGet("", ([FromServices] DAL<Empresa> dal) =>
            {
                return Results.Ok(EntityListToResponseList(dal.Listar()));
            });

            groubuilder.MapGet("{id}", ([FromServices] DAL<Empresa> dal, int id) =>
            {
                var empresa = dal.RecuperarPor(a => a.Id.Equals(id));

                if (empresa is null) return Results.NotFound();

                return Results.Ok(EntityToResponse(empresa));
            });

            groubuilder.MapPost("", ([FromServices] DAL<Empresa> dal, [FromBody] EmpresaRequest request) =>
            {             
                Empresa empresa = new()
                {
                    RazaoSocial = request.RazaoSocial,
                    CNPJ = request.CNPJ,
                    NomeFantasia = request.NomeFantasia,
                    Endereco = request.Endereco
                };
                
                if(request.Contatos is not null) empresa.Contatos = request.Contatos;               

                dal.Adicionar(empresa);

                return Results.Ok();

            });

            groubuilder.MapPut("{id}", ([FromServices] DAL<Empresa> dal, 
                                        [FromServices] DAL<Contato> dalContato, 
                                        [FromBody] EmpresaRequestEdit request, 
                                        int id) =>
            {
                var empresa = dal.RecuperarPor(e => e.Id == id);

                if(empresa  is null) return Results.NotFound();

                if(!request.RazaoSocial.IsNullOrEmpty()) empresa.RazaoSocial = request.RazaoSocial;
                if(!request.CNPJ.IsNullOrEmpty()) empresa.CNPJ = request.CNPJ;
                if(!request.NomeFantasia.IsNullOrEmpty()) empresa.NomeFantasia = request.NomeFantasia;

                if (request.Endereco is not null)
                {
                    empresa.Endereco.Logradouro = request.Endereco.Logradouro;
                    empresa.Endereco.Numero = request.Endereco.Numero;
                    empresa.Endereco.Localidade = request.Endereco.Localidade;
                    empresa.Endereco.Bairro = request.Endereco.Bairro;
                    empresa.Endereco.CEP = request.Endereco.CEP;
                    empresa.Endereco.Uf = request.Endereco.Uf;
                    empresa.Endereco.Complemento = request.Endereco.Complemento;
                }

                if (empresa.Contatos is not null)
                {                  
                    var contatosARemover = new List<Contato>();

                    foreach (var item in request.Contatos)
                        if (!empresa.Contatos.Contains(item)) empresa.Contatos.Add(item);

                    foreach (var item in empresa.Contatos)
                        if (!request.Contatos.Contains(item)) contatosARemover.Add(item);

                    foreach (var item in contatosARemover)
                        dalContato.Deletar(item);
                }

                dal.Atualizar(empresa);

                return Results.NoContent();

            });
                       
        }

        private static ICollection<EmpresaResponse> EntityListToResponseList(IEnumerable<Empresa> listaDeEmpresas)
        {
            return listaDeEmpresas.Select(a => EntityToResponse(a)).ToList();
        }

        private static EmpresaResponse EntityToResponse(Empresa empresa)
        {
            return new EmpresaResponse(empresa.Id, empresa.CNPJ, empresa.NomeFantasia, empresa.RazaoSocial, empresa.Endereco, empresa.Contatos);
        }
    }
}
