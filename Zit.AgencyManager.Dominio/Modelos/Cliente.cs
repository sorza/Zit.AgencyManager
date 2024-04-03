using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();
    }
}
