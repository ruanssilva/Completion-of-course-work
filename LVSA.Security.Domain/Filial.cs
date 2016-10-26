using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;

namespace LVSA.Security.Domain
{
    public class Filial : Auditoria
    {
        public short Id { get; set; }
        public string Nome { get; set; }
        public short ColigadaId { get; set; }
        public virtual Coligada Coligada { get; set; }
    }
}
