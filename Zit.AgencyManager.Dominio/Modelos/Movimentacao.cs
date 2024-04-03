using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zit.AgencyManager.Dominio.Modelos
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public int CaixaId { get; set; }
        public virtual Caixa Caixa { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public string? Descricao { get; set; }
    }
}
