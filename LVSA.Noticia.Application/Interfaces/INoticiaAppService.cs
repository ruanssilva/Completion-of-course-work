using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Noticia.Application.ViewModels;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Noticia.Application.Interfaces
{
    public interface INoticiaAppService : IAppServiceBase<NoticiaViewModel, Noticia.Domain.Noticia>
    {
        NoticiaViewModel ObterPorId(long id);
        void Contexto(NoticiaViewModel noticia, IEnumerable<FilialViewModel> niveis);
        void Visualiza(NoticiaViewModel noticia, UsuarioViewModel usuario);
    }
}
