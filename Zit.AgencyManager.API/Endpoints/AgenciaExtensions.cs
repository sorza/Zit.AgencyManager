using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata;
using Zit.AgencyManager.API.Request;
using Zit.AgencyManager.API.Response;
using Zit.AgencyManager.Dados.Banco;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Endpoints
{
    public static class AgenciaExtensions
    {
        public static void AddEndPointsContatos(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("agencias")              
                .WithTags("Agências");

            groupBuilder.MapGet("", ([FromServices] DAL<Agencia> dal) =>
            {
                var listaDeAgencias = dal.Listar();
                if (listaDeAgencias is null)
                {
                    return Results.NotFound();
                }
                var listaDeArtistaResponse = EntityListToResponseList(listaDeAgencias);
                return Results.Ok(listaDeAgencias);
            });

            groupBuilder.MapPost("", ([FromServices] DAL<Agencia> dal, [FromBody] AgenciaRequest request) =>
            {
                if(request is null) return Results.BadRequest();

                var agencia = new Agencia()
                {
                    CNPJ = request.CNPJ,
                    Descricao = request.Descricao,
                    Endereco = request.Endereco
                };

                if(request.Contatos is not  null) agencia.Contatos = request.Contatos;

                dal.Adicionar(agencia);

                return Results.Ok();
            });

            groupBuilder.MapPut("", ([FromServices] DAL<Agencia> dal, [FromBody] AgenciaRequestEdit request) =>
            {
                if (request is null) return Results.BadRequest();

                var agenciaAAtualizar = dal.RecuperarPor(ag => ag.Id == request.Id);
                
                if(agenciaAAtualizar is null) return Results.NotFound();

                agenciaAAtualizar.Ativa = request.Ativa;

                if (!request.CNPJ.IsNullOrEmpty() && request.CNPJ != agenciaAAtualizar.CNPJ) agenciaAAtualizar.CNPJ = request.CNPJ!;
                if (!request.Descricao.IsNullOrEmpty() && request.Descricao != agenciaAAtualizar.Descricao) agenciaAAtualizar.Descricao = request.Descricao!;
                
                if(request.Endereco is not null && !request.Endereco.Equals(agenciaAAtualizar.Endereco))
                {
                    agenciaAAtualizar.Endereco.CEP = request.Endereco.CEP;
                    agenciaAAtualizar.Endereco.Logradouro = request.Endereco.Logradouro;
                    agenciaAAtualizar.Endereco.Bairro = request.Endereco.Bairro;
                    agenciaAAtualizar.Endereco.Cidade = request.Endereco.Cidade;                   
                    agenciaAAtualizar.Endereco.Uf = request.Endereco.Uf;
                    agenciaAAtualizar.Endereco.Complemento = request.Endereco.Complemento;                   
                }

                if(request.Contatos is not null && agenciaAAtualizar.Contatos != request.Contatos)
                {
                    foreach(var item in agenciaAAtualizar.Contatos)
                    {
                        if(!request.Contatos.Contains(item)) agenciaAAtualizar.Contatos.Remove(item);
                    }

                    agenciaAAtualizar.Contatos.Concat(request.Contatos);
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
