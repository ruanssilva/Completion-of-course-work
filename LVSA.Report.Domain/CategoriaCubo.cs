using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Domain
{
    public class CategoriaCubo : AuditoriaComAtivo, IColigadaContexto
    {
        public int Id { get; set; }
        public short ColigadaId { get; set; }
        public string Nome { get; set; }
    }
}
