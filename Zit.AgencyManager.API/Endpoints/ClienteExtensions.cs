using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Zit.AgencyManager.API.Request;
using Zit.AgencyManager.API.Response;
using Zit.AgencyManager.Dados.Banco;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Endpoints
{
    public static class ClienteExtensions
    {
        public static void AddEndpointsClientes(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("clientes")
                                    .RequireAuthorization()
                                    .WithTags("Clientes");

            groupBuilder.MapGet("", ([FromServices] DAL<Cliente> dal) =>
            {
                return Results.Ok(EntityListToResponseList(dal.Listar()));
            });

            groupBuilder.MapGet("{id}", ([FromServices] DAL<Cliente> dal, int id) =>
            {
                var cliente = dal.RecuperarPor(c => c.Id == id);

                if (cliente is null) return Results.NotFound();

                return Results.Ok(EntityToResponse(cliente));
            });

            groupBuilder.MapPost("", ([FromServices] DAL < Cliente > dal, [FromBody] ClienteRequest request) =>
            {               
                Cliente cliente = new()
                {
                    Nome = request.Nome                    
                };

                if (request.Contatos is not null) cliente.Contatos = request.Contatos;

                dal.Adicionar(cliente);

                return Results.Ok();
            });

            groupBuilder.MapPut("{id}", ([FromServices] DAL<Cliente> dal,[FromServices] DAL<Contato> dalContato, [FromBody] ClienteRequestEdit request, int id) =>
            {
                var cliente = dal.RecuperarPor(c => c.Id == id);

                if (cliente is null) return Results.NotFound();

                if(request.Nome.IsNullOrEmpty()) cliente.Nome = request.Nome;

                if (request.Contatos is not null)
                {
                    var contatosARemover = new List<Contato>();

                    foreach (var item in request.Contatos)
                        if (!cliente.Contatos.Contains(item)) cliente.Contatos.Add(item);

                    foreach (var item in cliente.Contatos)
                        if (!request.Contatos.Contains(item)) cliente.Contatos.Remove(item);

                    foreach (var item in contatosARemover)
                        dalContato.Deletar(item);
                }

                return Results.NoContent();
            });

            groupBuilder.MapDelete("{id}", ([FromServices] DAL<Cliente> dal, int id) =>
            {
                var cliente = dal.RecuperarPor(c => c.Id == id);

                if (cliente is null) return Results.NotFound();

                dal.Deletar(cliente);

                return Results.NoContent();
            });
        }

        private static ClienteResponse EntityToResponse(Cliente cliente)
        {
            return new ClienteResponse(cliente.Id, cliente.Nome, cliente.Contatos);
        }

        private static IEnumerable<ClienteResponse> EntityListToResponseList(IEnumerable<Cliente> clienteList)
        {
            return clienteList.Select(c => EntityToResponse(c)).ToList();
        }
    }
}
