﻿using System.ComponentModel.DataAnnotations;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Web.Response
{
    public record ColaboradorResponse(
        int Id,
        string Nome,
        string CPF,
        string RG,
        DateOnly DataNascimento,
        Agencia Agencia,
        Cargo Cargo,
        DateOnly DataAdmissao,
        DateOnly DataDemissao,
        Endereco Endereco,
        ICollection<Contato> Contatos,
        Usuario Usuario,
        bool Ativo
     );
}