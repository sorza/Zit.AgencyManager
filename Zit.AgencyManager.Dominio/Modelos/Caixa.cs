using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Caixa
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime Data { get; set; }
        public decimal? TrocoInicial { get; set; }
        public decimal? TrocoFinal { get; set; }
        public bool Aberto { get; set; }
        public decimal Saldo { get; set; }
    }
}
