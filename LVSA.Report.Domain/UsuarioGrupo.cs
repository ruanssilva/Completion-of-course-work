
using LVSA.Base.Domain;

namespace LVSA.Report.Domain
{
    public class UsuarioGrupo : Auditoria
    {
        public long UsuarioId { get; set; }
        public int GrupoId { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}
