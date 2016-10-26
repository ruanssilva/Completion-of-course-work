using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Domain
{
    public class CuboParametro : Auditoria, IColigadaContexto
    {
        public int CuboId { get; set; }
        public int Numero { get; set; }
        public string Nome { get; set; }
        public bool Obrigatorio { get; set; }
        public short ColigadaId { get; set; }
        public virtual Cubo Cubo { get; set; }
    }
}
