using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
                                .RequireAuthorization()
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

            groubuilder.MapPost("", async ([FromServices] IHostEnvironment env, [FromServices] DAL<Empresa> dal, [FromBody] EmpresaRequest request) =>
            {
                var context = new ValidationContext(request);
                var results = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(request, context, results, true);

                if (!isValid)
                {
                    var errors = results.Select(x => x.ErrorMessage);
                    return Results.BadRequest(errors);
                }

                Empresa empresa = new()
                {
                    RazaoSocial = request.RazaoSocial,                   
                    NomeFantasia = request.NomeFantasia,
                    CNPJ = request.CNPJ,
                    Contatos = request.Contatos!
                };

                empresa.Endereco = new()
                {
                    CEP = request.Endereco.CEP,
                    Logradouro = request.Endereco.Logradouro,
                    Bairro = request.Endereco.Bairro,
                    Numero = request.Endereco.Numero,
                    Localidade = request.Endereco.Localidade,
                    Uf = request.Endereco.UF,
                    Complemento = request.Endereco.Complemento
                };

                if (request.Logo is not null)
                {
                    var nome = request.NomeFantasia!.Trim();
                    var logoEmpresa = DateTime.Now.ToString("ddMMyyyyhhss") + "." + nome + ".jpeg";

                    var path = Path.Combine(env.ContentRootPath,
                          "wwwroot", "LogosEmpresas", logoEmpresa);

                    using MemoryStream ms = new MemoryStream(Convert.FromBase64String(request.Logo!));
                    using FileStream fs = new(path, FileMode.Create);
                    await ms.CopyToAsync(fs);

                    empresa.Logo = $"LogosEmpresas/{logoEmpresa}";
                }

                dal.Adicionar(empresa);

                return Results.Ok();

            });

            groubuilder.MapPut("{id}", async([FromServices] IHostEnvironment env,[FromServices] DAL<Empresa> dal, [FromServices] DAL<Contato> dalContato, [FromBody] EmpresaRequestEdit request, int id) =>
            {
                var empresa = dal.RecuperarPor(e => e.Id == id);

                if(empresa  is null) return Results.NotFound();

                var context = new ValidationContext(request);
                var results = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(request, context, results, true);

                if (!isValid)
                {
                    var errors = results.Select(x => x.ErrorMessage);
                    return Results.BadRequest(errors);
                }

                empresa.RazaoSocial = request.RazaoSocial;
                empresa.CNPJ = request.CNPJ;
                empresa.NomeFantasia = request.NomeFantasia;

                empresa.Endereco.Logradouro = request.Endereco.Logradouro;
                empresa.Endereco.Numero = request.Endereco.Numero;
                empresa.Endereco.Localidade = request.Endereco.Localidade;
                empresa.Endereco.Bairro = request.Endereco.Bairro;
                empresa.Endereco.CEP = request.Endereco.CEP;
                empresa.Endereco.Uf = request.Endereco.UF;
                empresa.Endereco.Complemento = request.Endereco.Complemento;  
                                 
                var contatosARemover = new List<Contato>();

                foreach (var item in request.Contatos!)
                    if (!empresa.Contatos.Contains(item)) empresa.Contatos.Add(item);

                foreach (var item in empresa.Contatos)
                    if (!request.Contatos.Contains(item)) contatosARemover.Add(item);

                foreach (var item in contatosARemover)
                    dalContato.Deletar(item);

                if (request.Logo is not null && !request.Logo.Equals(empresa.Logo))
                {
                    var nome = request.NomeFantasia!.Trim();
                    var logoEmpresa = DateTime.Now.ToString("ddMMyyyyhhss") + "." + nome + ".jpeg";

                    var path = Path.Combine(env.ContentRootPath,
                          "wwwroot", "LogosEmpresas", logoEmpresa);

                    using MemoryStream ms = new MemoryStream(Convert.FromBase64String(request.Logo!));
                    using FileStream fs = new(path, FileMode.Create);
                    await ms.CopyToAsync(fs);

                    empresa.Logo = $"LogosEmpresas/{logoEmpresa}";
                }

                dal.Atualizar(empresa);

                return Results.NoContent();

            });

            groubuilder.MapDelete("{id}", ([FromServices] DAL<Empresa> dal, [FromServices] DAL<Contato> dalContato, [FromServices] DAL<Endereco> dalEndereco, int id) =>
            {
                var empresa = dal.RecuperarPor(a => a.Id.Equals(id));

                if (empresa is null) return Results.NotFound();

                var contatosARemover = new List<Contato>();

                foreach (var contato in empresa.Contatos)
                    contatosARemover.Add(contato);

                foreach (var contato in contatosARemover)
                    dalContato.Deletar(contato);

                dalEndereco.Deletar(empresa.Endereco);

                return Results.NoContent();
            });
        }

        private static ICollection<EmpresaResponse> EntityListToResponseList(IEnumerable<Empresa> listaDeEmpresas)
        {
            return listaDeEmpresas.Select(a => EntityToResponse(a)).ToList();
        }

        private static EmpresaResponse EntityToResponse(Empresa empresa)
        {
            return new EmpresaResponse(empresa.Id, empresa.RazaoSocial, empresa.NomeFantasia, empresa.CNPJ, empresa.Endereco, empresa.Contatos, empresa.Logo);
        }
    }
}
