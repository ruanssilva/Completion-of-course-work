using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain.Interfaces.Domain;
using LVSA.Base.Domain;

namespace LVSA.Security.Domain
{
    public class PerfilContexto : Auditoria, IOpcionalContexto
    {
        public long UsuarioId { get; set; }
        public int AplicacaoId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Aplicacao Aplicacao { get; set; }
        public short? CODTIPOCURSO { get; set; }
        public short? FilialId { get; set; }
        public short? ColigadaId { get; set; }
    }
}
