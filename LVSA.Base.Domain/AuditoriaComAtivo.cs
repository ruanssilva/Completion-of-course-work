using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Base.Domain
{
    public abstract class AuditoriaComAtivo : Auditoria
    {
        /// <summary>
        /// Campo de ativo/inativo para o modelo. Para valor igual a 'true' o modelo está ativo
        /// </summary>
        public bool Ativo { get; set; }
    }
}
