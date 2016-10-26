using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Base.Domain
{
    public abstract class AuditoriaComExclusaoLogica : Auditoria
    {
        /// <summary>
        /// Campo de exclusão virtual. Para valor diferente de 'null' corresponde a exclusão do registro no modelo
        /// </summary>
        public DateTime? RECDELETEDON { get; set; }
        /// <summary>
        /// Campo de auditoria de exclusão virtual
        /// </summary>
        public string RECDELETEDBY { get; set; }
    }
}
