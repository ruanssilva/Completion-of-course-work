using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;

namespace LVSA.Security.Domain
{
    public class UsuarioFilial : Auditoria, IFilialContexto
    {
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
        public long UsuarioId { get; set; }
        public string Acesso { get; set; }
        public virtual Usuario Usuario { get; set; }

        public virtual Coligada Coligada { get; set; }
        public virtual Filial Filial { get; set; }
    }
}
