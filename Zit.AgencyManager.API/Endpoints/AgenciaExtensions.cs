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

                if (agencia is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(EntityToResponse(agencia));

            });

            groupBuilder.MapPost("", ([FromServices] DAL<Agencia> dal,[FromBody] AgenciaRequest request) =>
            {
                if(request is null) return Results.BadRequest();

                Agencia agencia = new()
                {
                    CNPJ = request.CNPJ,
                    Descricao = request.Descricao,  
                    Endereco = request.Endereco
                };

                if(request.Contatos is not  null) agencia.Contatos = request.Contatos;

                dal.Adicionar(agencia);

                return Results.Ok();
            });

            groupBuilder.MapPut("{id}", ([FromServices] DAL<Agencia> dal, [FromServices]DAL<Contato> dalContato,[FromBody] AgenciaRequestEdit request, int id) =>
            {
                if (request is null) return Results.BadRequest();

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
               
                dal.Atualizar(agenciaAAtualizar);

                return Results.NoContent();
               
            });
        }

        private static ICollection<AgenciaResponse> EntityListToResponseList(IEnumerable<Agencia> listaDeAgencias)
        {
            return listaDeAgencias.Select(a => EntityToResponse(a)).ToList();
        }

        private static AgenciaResponse EntityToResponse(Agencia agencia)
        {
            return new AgenciaResponse(agencia.Id, agencia.Descricao, agencia.CNPJ, agencia.Endereco, agencia.Contatos);
        }              
    }
}
