using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zit.AgencyManager.Dominio.Modelos
{
    public class VendaVirtual
    {
        public int Id { get; set; }
        public int CaixaId { get; set; }
        public virtual Caixa Caixa { get; set; }
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int OrigemId { get; set; }
        public virtual Localidade Origem { get; set; }
        public int DestinoId { get; set; }
        public virtual Localidade Destino { get; set; }
        public decimal Valor { get; set; }
        public string FormaPagamento { get; set; }
        public string? Observacao { get; set; }
    }
}
