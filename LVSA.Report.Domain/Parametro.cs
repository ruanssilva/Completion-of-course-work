using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Domain
{
    public class Parametro : Auditoria, IColigadaContexto
    {
        public int Id { get; set; }
        public short ColigadaId { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Mask { get; set; }
        public string DataType { get; set; }        
        public string Icon { get; set; }
        public string Regex { get; set; }
        public string Consulta { get; set; }
        public bool Multivaloravel { get; set; }
    }
}
