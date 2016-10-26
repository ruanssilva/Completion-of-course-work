using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Domain
{
    public class PermissaoCubo : AuditoriaComAtivo, IColigadaContexto
    {
        public int Id { get; set; }
        public short ColigadaId { get; set; }
        public int CuboId { get; set; }
        public int? GrupoId { get; set; }
        public int? UsuarioId { get; set; }
        public bool Acesso { get; set; }
        public virtual Cubo Cubo { get; set; }
    }
}
