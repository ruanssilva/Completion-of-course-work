using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;

namespace LVSA.Noticia.Domain
{
    public class NoticiaContexto : Auditoria, IFilialContexto
    {
        public long NoticiaId { get; set; }
        public short ColigadaId { get; set; }
        public short FilialId { get; set; }
    }
}
