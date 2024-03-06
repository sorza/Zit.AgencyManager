using Microsoft.AspNetCore.Identity;

namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Usuario : IdentityUser
    {
        public int ColaboradorId { get; set; }
        public virtual Colaborador Colaborador { get; set; }
    }
}
