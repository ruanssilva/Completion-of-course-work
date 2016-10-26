using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Domain;

namespace LVSA.Security.Application.Interfaces
{
    public interface IGrupoAppService : IAppServiceBase<GrupoViewModel,Grupo>
    {
        IEnumerable<GrupoViewModel> Filtrar(Expression<Func<Grupo, bool>> predicate, bool usuario);
        GrupoViewModel ObterPorId(long id);
        void Agrupar(GrupoViewModel model);
        void Permitir(GrupoViewModel model);
        void Esvaziar(GrupoViewModel model);
        void Retirar(GrupoViewModel grupo, UsuarioViewModel usuario);
    }
}
