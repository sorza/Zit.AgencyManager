using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
                Agencia agencia = new()
                {
                    CNPJ = request.CNPJ,
                    Descricao = request.Descricao,  
                    Endereco = request.Endereco
                };

                if(request.Contatos is not null) agencia.Contatos = request.Contatos;

                if(request.Foto is not null)
                {
                    var nome = request.Descricao.Trim();
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

            groupBuilder.MapPut("{id}", async([FromServices]IHostEnvironment env,[FromServices] DAL<Agencia> dal, [FromServices]DAL<Contato> dalContato,[FromBody] AgenciaRequestEdit request, int id) =>
            {
                var agenciaAAtualizar = dal.RecuperarPor(ag => ag.Id == id);
                
                if(agenciaAAtualizar is null) return Results.NotFound();

                if (!request.CNPJ.IsNullOrEmpty() && request.CNPJ != agenciaAAtualizar.CNPJ) agenciaAAtualizar.CNPJ = request.CNPJ!;
                if (!request.Descricao.IsNullOrEmpty() && request.Descricao != agenciaAAtualizar.Descricao) agenciaAAtualizar.Descricao = request.Descricao!;
                if (request.Ativa != agenciaAAtualizar.Ativa) agenciaAAtualizar.Ativa = request.Ativa;
                             
                if(request.Endereco is not null)
                {
                    agenciaAAtualizar.Endereco.Logradouro = request.Endereco.Logradouro;
                    agenciaAAtualizar.Endereco.Numero = request.Endereco.Numero;
                    agenciaAAtualizar.Endereco.Cidade = request.Endereco.Cidade;
                    agenciaAAtualizar.Endereco.Bairro = request.Endereco.Bairro;
                    agenciaAAtualizar.Endereco.CEP = request.Endereco.CEP;
                    agenciaAAtualizar.Endereco.Uf = request.Endereco.Uf;
                    agenciaAAtualizar.Endereco.Complemento = request.Endereco.Complemento;
                }

                if(request.Contatos is not null)
                {                   
                    var contatosARemover = new List<Contato>();

                    foreach(var item in request.Contatos)
                        if(!agenciaAAtualizar.Contatos.Contains(item)) agenciaAAtualizar.Contatos.Add(item);

                    foreach(var item in agenciaAAtualizar.Contatos)
                        if(!request.Contatos.Contains(item)) contatosARemover.Add(item);

                    foreach (var item in contatosARemover)
                        dalContato.Deletar(item);
                }

                if (request.Foto is not null && !request.Foto.Equals(agenciaAAtualizar.Foto))
                {
                    var nome = request.Descricao.Trim();
                    var imagemAgencia = DateTime.Now.ToString("ddMMyyyyhhss") + "." + nome + ".jpeg";

                    var path = Path.Combine(env.ContentRootPath,
                          "wwwroot", "FotosAgencia", imagemAgencia);

                    using MemoryStream ms = new MemoryStream(Convert.FromBase64String(request.Foto!));
                    using FileStream fs = new(path, FileMode.Create);
                    await ms.CopyToAsync(fs);

                    agenciaAAtualizar.Foto = $"FotosAgencia/{imagemAgencia}";
                }

                dal.Atualizar(agenciaAAtualizar);

                return Results.NoContent();
               
            });

            groupBuilder.MapDelete("{id}", ([FromServices] DAL<Agencia> dalAgencia, [FromServices]DAL<Contato> dalContato, int id) =>
            {
                var agencia = dalAgencia.RecuperarPor(ag => ag.Id == id);

                if (agencia is null) return Results.NotFound();

                var contatosARemover = new List<Contato>();

                foreach (var contato in agencia.Contatos)
                    contatosARemover.Add(contato);

                foreach(var contato in contatosARemover)
                    dalContato.Deletar(contato);

                dalAgencia.Deletar(agencia);

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
