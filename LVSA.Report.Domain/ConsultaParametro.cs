using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Domain
{
    public class ConsultaParametro : Auditoria, IColigadaContexto
    {
        public int ConsultaId { get; set; }
        public int ParametroId { get; set; }
        public int Numero { get; set; }
        public string Descricao { get; set; }
        public short ColigadaId { get; set; }
        public virtual Consulta Consulta { get; set; }
        public virtual Parametro Parametro { get; set; }
    }
}
