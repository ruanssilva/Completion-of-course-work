using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain;

namespace LVSA.Noticia.Domain
{
    public class NoticiaAplicacao : Auditoria
    {
        public long NoticiaId { get; set; }
        public int AplicacaoId { get; set; }
    }
}
