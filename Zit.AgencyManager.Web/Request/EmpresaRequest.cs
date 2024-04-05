﻿using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Web.Request
{
    public record EmpresaRequest(
        [Required] string RazaoSocial,
        [Required] string NomeFantasia,
        [Required] string CNPJ,
        [Required] Endereco Endereco,
        ICollection<Contato> Contatos
    );
}