using LVSA.Base.Domain;
using LVSA.Base.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Social.Domain
{
    public class Notificacao : AuditoriaComExclusaoLogica, IColigadaContexto
    {
        public long Id { get; set; }
        public string Texto { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public long UsuarioId { get; set; }
        public DateTime? Visualizado { get; set; }
        public DateTime? Clicado { get; set; }
        public short ColigadaId { get; set; }
    }
}
