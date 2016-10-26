using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;

namespace LVSA.Security.Domain
{
    public class NotificacaoVisualizada : Auditoria
    {
        public long UsuarioId { get; set; }
        public long NotificacaoId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Notificacao Notificacao { get; set; }
    }
}
