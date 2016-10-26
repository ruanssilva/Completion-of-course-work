using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Base.Domain
{
    public abstract class Auditoria
    {
        /// <summary>
        /// Campo de auditoria de data/horário de criação
        /// </summary>
        public DateTime? RECCREATEDON { get; set; }
        /// <summary>
        /// Campo de auditoria de criação
        /// </summary>
        public string RECCREATEDBY { get; set; }
        /// <summary>
        /// Campo de auditoria de data/horário de criação
        /// </summary>
        public DateTime? RECMODIFIEDON { get; set; }
        /// <summary>
        /// Campo de auditoria de criação
        /// </summary>
        public string RECMODIFIEDBY { get; set; }
    }
}
