using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Base.Domain.Interfaces.Domain
{
    public interface IOpcionalContexto
    {
        /// <summary>
        /// Campo para filtro de informação. Para valor igual a 'null' corresponde que todas coligadas terão acesso a informação
        /// </summary>
        short? ColigadaId { get; set; }
        /// <summary>
        /// Campo para filtro de informação. Para valor igual a 'null' corresponde que todas filiais terão acesso a informação
        /// </summary>
        short? FilialId { get; set; }
    }
}
