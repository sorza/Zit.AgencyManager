using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.API.Request;
using Zit.AgencyManager.API.Response;
using Zit.AgencyManager.Dados.Banco;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Endpoints
{
    public static class ColaboradorExtensions
    {
        public static void AddEndpointsColaboradores(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("colaboradores")
                .WithTags("Colaboradores");

            groupBuilder.MapGet("", ([FromServices] DAL<Colaborador> dal) =>
            {
                return Results.Ok(EntityListToResponseList(dal.Listar()));
            });

            groupBuilder.MapGet("{id}", ([FromServices] DAL<Colaborador> dal, int id) =>
            {
                var colaborador = dal.RecuperarPor(a => a.Id.Equals(id));

                if (colaborador is null) return Results.NotFound();
               
                return Results.Ok(EntityToResponse(colaborador));
            });

            groupBuilder.MapPost("", ([FromServices] DAL<Colaborador> dal, [FromBody] ColaboradorRequest request) =>
            {
                var context = new ValidationContext(request);
                var results = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(request, context, results, true);

                if (!isValid)
                {
                    var errors = results.Select(x => x.ErrorMessage);
                    return Results.BadRequest(errors);
                }

                var colaborador = new Colaborador()
                {                   
                    Nome = request.Nome,
                    RG = request.RG,
                    CPF = request.CPF,
                    DataNascimento = request.DataNascimento,
                    AgenciaId = request.AgenciaId,
                    CargoId = request.CargoId,
                    DataAdmissao = request.DataAdmissao,
                    UsuarioId = request.UsuarioId
                };

                colaborador.Endereco = new()
                {
                    CEP = request.Endereco.CEP,
                    Logradouro = request.Endereco.Logradouro,
                    Bairro = request.Endereco.Bairro,
                    Numero = request.Endereco.Numero,
                    Localidade = request.Endereco.Localidade,
                    Uf = request.Endereco.UF,
                    Complemento = request.Endereco.Complemento
                };

                colaborador.Contatos = request.Contatos;

                dal.Adicionar(colaborador);

                return Results.Ok();
            });

            groupBuilder.MapPut("{id}", ([FromServices] DAL<Colaborador> dal, [FromServices] DAL<Contato> dalContato,[FromBody] ColaboradorRequestEdit request, int id) =>
            {              
                var colaborador = dal.RecuperarPor(c => c.Id == id);

                if (colaborador is null) return Results.NotFound();

                var context = new ValidationContext(request);
                var results = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(request, context, results, true);

                if (!isValid)
                {
                    var errors = results.Select(x => x.ErrorMessage);
                    return Results.BadRequest(errors);
                }

                colaborador.Nome = request.Nome;
                colaborador.RG = request.RG;
                colaborador.CPF = request.CPF;
                colaborador.DataNascimento = request.DataNascimento;
                colaborador.AgenciaId = request.AgenciaId;
                colaborador.CargoId = request.CargoId;
                colaborador.DataAdmissao = request.DataAdmissao;                
                colaborador.DataDemissao = request.DataDemissao;
                colaborador.Ativo = request.Ativo;                
                
                colaborador.Endereco.Logradouro = request.Endereco.Logradouro;
                colaborador.Endereco.Numero = request.Endereco.Numero;
                colaborador.Endereco.Localidade = request.Endereco.Localidade;
                colaborador.Endereco.Bairro = request.Endereco.Bairro;
                colaborador.Endereco.CEP = request.Endereco.CEP;
                colaborador.Endereco.Uf = request.Endereco.UF;
                colaborador.Endereco.Complemento = request.Endereco.Complemento;
                

                var contatosARemover = new List<Contato>();

                foreach (var item in request.Contatos)
                    if (!colaborador.Contatos.Contains(item)) colaborador.Contatos.Add(item);

                foreach (var item in colaborador.Contatos)
                    if (!request.Contatos.Contains(item)) colaborador.Contatos.Remove(item);

                foreach (var item in contatosARemover)
                    dalContato.Deletar(item);
                

                dal.Atualizar(colaborador);             

                return Results.NoContent();

            });

            groupBuilder.MapDelete("{id}", ([FromServices] DAL<Colaborador> dal, [FromServices] DAL<Contato> dalContato,[FromServices] DAL<Endereco> dalEndereco, [FromServices] DAL<Usuario> dalUsuario, int id) =>
            {
                var colaborador = dal.RecuperarPor(c=>c.Id == id);
                
                if (colaborador is null) return Results.NotFound();

                var contatosARemover = new List<Contato>();

                foreach (var contato in colaborador.Contatos)
                    contatosARemover.Add(contato);

                foreach (var contato in contatosARemover)
                    dalContato.Deletar(contato);

                var enderecoARemover = colaborador.Endereco;

                dalUsuario.Deletar(colaborador.Usuario);

                dalEndereco.Deletar(enderecoARemover);
                

                return Results.NoContent();
            });
        }

        private static ICollection<ColaboradorResponse> EntityListToResponseList(IEnumerable<Colaborador> listaDeColaboradores)
        {
            return listaDeColaboradores.Select(a => EntityToResponse(a)).ToList();
        }
        private static ColaboradorResponse EntityToResponse(Colaborador colaborador)
        {
            return new ColaboradorResponse(colaborador.Id, colaborador.Nome, colaborador.CPF, colaborador.RG, colaborador.DataNascimento, colaborador.Agencia, colaborador.Cargo, colaborador.DataAdmissao, colaborador.DataDemissao, colaborador.Endereco, colaborador.Contatos, colaborador.Usuario, colaborador.Ativo);
        }
    }
}
