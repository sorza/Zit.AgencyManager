﻿using System.ComponentModel.DataAnnotations;

namespace Zit.AgencyManager.API.Request
{
    public record CaixaRequest
    (
        [Required]
        int ColaboradorId
    );
}
