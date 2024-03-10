﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Zit.AgencyManager.API.Request;
using Zit.AgencyManager.API.Response;
using Zit.AgencyManager.Dados.Banco;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Endpoints
{
    public static class ColaboradorExtensions
    {
        public static void AddEndPointsColaboradores(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("colaboradores")
                .WithTags("Colaboradores");

            groupBuilder.MapGet("", ([FromServices] DAL<Colaborador> dal) =>
            {
                var listaDeColaboradores = dal.Listar();
                if (listaDeColaboradores is null)
                {
                    return Results.NotFound();
                }
                var listaDeColaboradorResponse = EntityListToResponseList(listaDeColaboradores);
                return Results.Ok(listaDeColaboradorResponse);
            });

            groupBuilder.MapGet("{id}", ([FromServices] DAL<Colaborador> dal, int id) =>
            {
                var colaborador = dal.RecuperarPor(a => a.Id.Equals(id));

                if (colaborador is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(EntityToResponse(colaborador));
            });

            groupBuilder.MapPost("", ([FromServices] DAL<Colaborador> dal, [FromBody] ColaboradorRequest request) =>
            {
                if(request is null) return Results.BadRequest();

                var colaborador = new Colaborador()
                {                   
                    Nome = request.Nome,
                    RG = request.RG,
                    CPF = request.CPF,
                    DataNascimento = request.DataNascimento,
                    AgenciaId = request.AgenciaId,
                    CargoId = request.CargoId,
                    DataAdmissao = request.DataAdmissao,
                    Endereco = request.Endereco                    
                };

                if (request.Contatos is not null) colaborador.Contatos = request.Contatos;

                dal.Adicionar(colaborador);

                return Results.Created();
            });

            groupBuilder.MapPut("{id}", ([FromServices] DAL<Colaborador> dal, [FromBody] ColaboradorRequestEdit request, int id) =>
            {
                if (request is null) return Results.BadRequest();

                var colaborador = dal.RecuperarPor(c => c.Id == id);

                if (colaborador is null) return Results.NotFound();

                if(!request.Nome.IsNullOrEmpty() && !request.Nome.Equals(colaborador.Nome)) colaborador.Nome = request.Nome;
                if(!request.RG.IsNullOrEmpty() && !request.RG.Equals(colaborador.RG)) colaborador.RG = request.RG;
                if(!request.CPF.IsNullOrEmpty() && !request.CPF.Equals(colaborador.CPF)) colaborador.CPF = request.CPF;
                if(request.DataNascimento != DateOnly.MinValue && !request.DataNascimento.Equals(colaborador.DataNascimento)) colaborador.DataNascimento = request.DataNascimento;
                if(request.AgenciaId > 0 && !request.AgenciaId.Equals(colaborador.AgenciaId)) colaborador.AgenciaId = request.AgenciaId;
                if(request.CargoId > 0 && !request.CargoId.Equals(colaborador.CargoId)) colaborador.CargoId = request.CargoId;
                if(request.DataAdmissao != DateOnly.MinValue && !request.DataAdmissao.Equals(colaborador.DataAdmissao)) colaborador.DataAdmissao = request.DataAdmissao;
                if(request.DataDemissao != DateOnly.MinValue && !request.DataDemissao.Equals(colaborador.DataDemissao)) colaborador.DataDemissao = request.DataDemissao;

                if (request.Endereco is not null && !request.Endereco.Equals(colaborador.Endereco))
                {
                    colaborador.Endereco.Logradouro = request.Endereco.Logradouro;
                    colaborador.Endereco.Bairro = request.Endereco.Bairro;
                    colaborador.Endereco.Cidade = request.Endereco.Cidade;  
                    colaborador.Endereco.CEP = request.Endereco.CEP;
                    colaborador.Endereco.Complemento = request.Endereco.Complemento;
                    colaborador.Endereco.Uf = request.Endereco.Uf;
                }

                if (request.Ativo != colaborador.Ativo) colaborador.Ativo = request.Ativo;

                dal.Atualizar(colaborador);

                return Results.NoContent();

            });
        }

        private static ICollection<ColaboradorResponse> EntityListToResponseList(IEnumerable<Colaborador> listaDeColaboradores)
        {
            return listaDeColaboradores.Select(a => EntityToResponse(a)).ToList();
        }

        private static ColaboradorResponse EntityToResponse(Colaborador colaborador)
        {
            return new ColaboradorResponse(colaborador.Id, colaborador.Nome, colaborador.RG, colaborador.CPF, colaborador.DataNascimento, colaborador.Agencia, colaborador.Cargo, colaborador.DataAdmissao, colaborador.DataDemissao, colaborador.Endereco, colaborador.Contatos);
        }
    }
}