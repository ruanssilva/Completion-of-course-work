using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain.Services;
using LVSA.Noticia.Domain.Interfaces.Repository;
using LVSA.Noticia.Domain.Interfaces.Services;

namespace LVSA.Noticia.Domain.Services
{
    public class NoticiaAplicacaoService : ServiceBase<NoticiaAplicacao>, INoticiaAplicacaoService
    {
        public NoticiaAplicacaoService(INoticiaAplicacaoRepository repository)
            : base(repository)
        {

        }
    }
}
