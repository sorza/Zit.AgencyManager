﻿using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.Web.Request
{
    public record UsuarioRequest
    (
        [Required]
        string Email,
        [Required]
        string Password
    );
}