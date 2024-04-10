using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.API.Request;
using Zit.AgencyManager.API.Response;
using Zit.AgencyManager.Dados.Banco;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.API.Endpoints
{
    public static class ContratoAgenciaEmpresaExtensions
    {
        public static void AddEndpointsContratoAgenciaEmpresas(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("contratos").WithTags("Contratos Agência-Empresas");

            groupBuilder.MapGet("", ([FromServices] DAL<ContratoAgenciaEmpresa> dal) => 
            {
                return Results.Ok(EntityListToResponseList(dal.Listar()));
            });

            groupBuilder.MapGet("{id}", ([FromServices] DAL<ContratoAgenciaEmpresa> dal, int id) => 
            {
                var contrato = dal.RecuperarPor(a => a.Id.Equals(id));

                if (contrato is null) return Results.NotFound();
              
                return Results.Ok(EntityToResponse(contrato));
            });

            groupBuilder.MapPost("", ([FromServices] DAL<ContratoAgenciaEmpresa> dal, [FromBody] ContratoAgenciaEmpresaRequest request) => 
            {
                var context = new ValidationContext(request);
                var results = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(request, context, results, true);

                if (!isValid)
                {
                    var errors = results.Select(x => x.ErrorMessage);
                    return Results.BadRequest(errors);
                }

                ContratoAgenciaEmpresa contrato = new()
                {
                    Ativo = true,
                    AgenciaId = request.AgenciaId,
                    EmpresaId = request.EmpresaId,
                    DataContrato = request.DataContrato,
                    Comissao = request.Comissao,
                    ModalidadeComissao = request.ModalidadeComissao,                    
                    FrequenciaAcerto = request.FrequenciaAcerto,
                    ModalidadeAcerto = request.ModalidadeAcerto,
                    EmiteNota = request.EmiteNota
                };

                dal.Adicionar(contrato);

                return Results.Ok();
            });

            groupBuilder.MapPut("{id}", ([FromServices] DAL<ContratoAgenciaEmpresa> dal, ContratoAgenciaEmpresaRequestEdit request,int id) => 
            { 
                var contrato = dal.RecuperarPor(c => c.Id == id);

                if (contrato is null) return Results.BadRequest();

                contrato.Ativo = request.Ativo;
                contrato.EmiteNota = request.EmiteNota;

                if(request.DataDistrato != DateOnly.MinValue && request.DataDistrato != contrato.DataDistrato) contrato.DataDistrato = request.DataDistrato;
                if(request.DataContrato != DateOnly.MinValue && request.DataContrato != contrato.DataContrato) contrato.DataContrato = request.DataContrato;
                if(request.Comissao > 0 && request.Comissao <100) contrato.Comissao = request.Comissao;
                if(!request.ModalidadeComissao.IsNullOrEmpty() && !request.ModalidadeComissao.Equals(contrato.ModalidadeComissao)) contrato.ModalidadeComissao = request.ModalidadeComissao;
                if(request.AgenciaId > 0 && request.AgenciaId !=  contrato.AgenciaId) contrato.AgenciaId = request.AgenciaId;
                if(request.EmpresaId > 0 && request.EmpresaId != contrato.EmpresaId) contrato.EmpresaId = request.EmpresaId;
                if(!request.ModalidadeAcerto.IsNullOrEmpty() && !request.ModalidadeAcerto.Equals(contrato.ModalidadeAcerto)) contrato.ModalidadeAcerto = request.ModalidadeAcerto;
                if(!request.FrequenciaAcerto.IsNullOrEmpty() && !request.FrequenciaAcerto.Equals(contrato.FrequenciaAcerto)) contrato.FrequenciaAcerto = request.FrequenciaAcerto;
                
                dal.Atualizar(contrato);

                return Results.NoContent();
            });

            groupBuilder.MapDelete("{id}", ([FromServices] DAL<ContratoAgenciaEmpresa> dal, int id) =>
            {
                var contrato = dal.RecuperarPor(x=>x.Id == id);

                if (contrato is null) return Results.NotFound();

                dal.Deletar(contrato);

                return Results.NoContent();
            });
           
        }
        private static ICollection<ContratoAgenciaEmpresaResponse> EntityListToResponseList(IEnumerable<ContratoAgenciaEmpresa> listaDeContratos)
        {
            return listaDeContratos.Select(a => EntityToResponse(a)).ToList();
        }

        private static ContratoAgenciaEmpresaResponse EntityToResponse(ContratoAgenciaEmpresa contrato)
        {
            return new ContratoAgenciaEmpresaResponse(contrato.Id, contrato.Ativo,contrato.Agencia,contrato.Empresa, contrato.Comissao, contrato.ModalidadeComissao, contrato.FrequenciaAcerto, contrato.ModalidadeAcerto, contrato.EmiteNota, contrato.DataContrato, contrato.DataDistrato);
        }
    }
}
