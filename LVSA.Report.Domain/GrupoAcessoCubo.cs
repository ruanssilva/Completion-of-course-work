
using LVSA.Base.Domain;

namespace LVSA.Report.Domain
{
    public class GrupoAcessoCubo : Auditoria
    {
        public int GrupoId { get; set; }
        public int CuboId { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual Cubo Cubo { get; set; }
    }
}
