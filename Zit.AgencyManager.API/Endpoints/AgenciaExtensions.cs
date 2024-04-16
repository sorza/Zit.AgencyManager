using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.API.Request;
using Zit.AgencyManager.API.Response;
using Zit.AgencyManager.Dados.Banco;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Endpoints
{
    public static class AgenciaExtensions
    {
        public static void AddEndpointsContatos(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("agencias") 
                                    .RequireAuthorization()
                                    .WithTags("Agências");

            groupBuilder.MapGet("", ([FromServices] DAL<Agencia> dal) =>
            {               
                return Results.Ok(EntityListToResponseList(dal.Listar()));
            });

            groupBuilder.MapGet("{id}", ([FromServices] DAL<Agencia> dal, int id) =>
            {
                var agencia = dal.RecuperarPor(a => a.Id.Equals(id));

                if (agencia is null) return Results.NotFound();

                return Results.Ok(EntityToResponse(agencia));

            });

            groupBuilder.MapPost("", async ([FromServices]IHostEnvironment env,[FromServices] DAL<Agencia> dal,[FromBody] AgenciaRequest request) =>
            {
                var context = new ValidationContext(request);
                var results = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(request, context, results, true);

                if (!isValid)
                {
                    var errors = results.Select(x => x.ErrorMessage);
                    return Results.BadRequest(errors);
                }

                Agencia agencia = new()
                {
                    CNPJ = request.CNPJ!,
                    Descricao = request.Descricao!,
                    Contatos = request.Contatos!
                };

                agencia.Endereco = new()
                {
                    CEP = request.Endereco.CEP,
                    Logradouro = request.Endereco.Logradouro,
                    Bairro = request.Endereco.Bairro,
                    Numero = request.Endereco.Numero,
                    Localidade = request.Endereco.Localidade,
                    Uf = request.Endereco.UF,
                    Complemento = request.Endereco.Complemento
                };

                if (request.Foto is not null)
                {
                    var nome = request.Descricao!.Trim();
                    var imagemAgencia = DateTime.Now.ToString("ddMMyyyyhhss") + "." + nome + ".jpeg";

                    var path = Path.Combine(env.ContentRootPath,
                          "wwwroot", "FotosAgencia", imagemAgencia);

                    using MemoryStream ms = new MemoryStream(Convert.FromBase64String(request.Foto!));
                    using FileStream fs = new(path, FileMode.Create);
                    await ms.CopyToAsync(fs);

                    agencia.Foto = $"FotosAgencia/{imagemAgencia}";
                }

                dal.Adicionar(agencia);

                return Results.Ok();
            });

            groupBuilder.MapPut("{id}", async([FromServices]IHostEnvironment env, [FromServices] DAL<Agencia> dal, [FromServices]DAL<Contato> dalContato, [FromBody] AgenciaRequestEdit request, int id) =>
            {
                var agencia = dal.RecuperarPor(ag => ag.Id == id);
                
                if(agencia is null) return Results.NotFound();

                var context = new ValidationContext(request);
                var results = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(request, context, results, true);

                if (!isValid)
                {
                    var errors = results.Select(x => x.ErrorMessage);
                    return Results.BadRequest(errors);
                }

                agencia.CNPJ = request.CNPJ!;
                agencia.Descricao = request.Descricao!;
                agencia.Ativa = request.Ativa;                             
                
                agencia.Endereco.Logradouro = request.Endereco.Logradouro;
                agencia.Endereco.Numero = request.Endereco.Numero;
                agencia.Endereco.Localidade = request.Endereco.Localidade;
                agencia.Endereco.Bairro = request.Endereco.Bairro;
                agencia.Endereco.CEP = request.Endereco.CEP;
                agencia.Endereco.Uf = request.Endereco.UF;
                agencia.Endereco.Complemento = request.Endereco.Complemento;
                
                                                  
                var contatosARemover = new List<Contato>();

                foreach(var item in request.Contatos!)
                    if(!agencia.Contatos.Contains(item)) agencia.Contatos.Add(item);

                foreach(var item in agencia.Contatos)
                    if(!request.Contatos.Contains(item)) contatosARemover.Add(item);

                foreach (var item in contatosARemover)
                    dalContato.Deletar(item);
                

                if (request.Foto is not null && !request.Foto.Equals(agencia.Foto))
                {
                    var nome = request.Descricao!.Trim();
                    var imagemAgencia = DateTime.Now.ToString("ddMMyyyyhhss") + "." + nome + ".jpeg";

                    var path = Path.Combine(env.ContentRootPath,
                          "wwwroot", "FotosAgencia", imagemAgencia);

                    using MemoryStream ms = new MemoryStream(Convert.FromBase64String(request.Foto!));
                    using FileStream fs = new(path, FileMode.Create);
                    await ms.CopyToAsync(fs);

                    agencia.Foto = $"FotosAgencia/{imagemAgencia}";
                }

                dal.Atualizar(agencia);

                return Results.NoContent();
               
            });

            groupBuilder.MapDelete("{id}", ([FromServices] DAL<Agencia> dalAgencia,[FromServices] DAL<Contato> dalContato, [FromServices] DAL<Endereco> dalEndereco, int id) =>
            {
                var agencia = dalAgencia.RecuperarPor(ag => ag.Id == id);

                if (agencia is null) return Results.NotFound();

                var contatosARemover = new List<Contato>();

                foreach (var contato in agencia.Contatos)
                    contatosARemover.Add(contato);

                foreach(var contato in contatosARemover)
                    dalContato.Deletar(contato);

                dalEndereco.Deletar(agencia.Endereco);

                return Results.NoContent();

            });
        }

        private static ICollection<AgenciaResponse> EntityListToResponseList(IEnumerable<Agencia> listaDeAgencias)
        {
            return listaDeAgencias.Select(a => EntityToResponse(a)).ToList();
        }

        private static AgenciaResponse EntityToResponse(Agencia agencia)
        {
            return new AgenciaResponse(agencia.Id, agencia.Descricao, agencia.CNPJ, agencia.Ativa, agencia.Endereco, agencia.Contatos, agencia.Foto);
        }              
    }
}
