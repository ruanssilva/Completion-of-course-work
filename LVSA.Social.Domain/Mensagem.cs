using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Social.Domain
{
    public class Mensagem : AuditoriaComExclusaoLogica, IColigadaContexto
    {
        public long Id { get; set; }
        public string Texto { get; set; }
        public DateTime Horario { get; set; }
        public long DUsuarioId { get; set; }
        public long PUsuarioId { get; set; }
        public short ColigadaId { get; set; }
        public DateTime? Visualizado { get; set; }
    }
}
