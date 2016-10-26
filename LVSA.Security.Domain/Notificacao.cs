using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;

namespace LVSA.Security.Domain
{
    public class Notificacao : Auditoria, IOpcionalContexto
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Mensagem { get; set; }
        public string Link { get; set; }
        public bool Blank { get; set; }
        public string Icon { get; set; }
        public DateTime NotificadoEm { get; set; }
        public long? UsuarioId { get; set; }
        public long? GrupoId { get; set; }
        public int? AplicacaoId { get; set; }
        public short? ColigadaId { get; set; }
        public short? FilialId { get; set; }
        public short? CODTIPOCURSO { get; set; }
        public virtual Aplicacao Aplicacao { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
