using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Base.Application.Interfaces
{
    public interface IAppServiceBase<TViewModel, TEntity>
        where TViewModel : class
        where TEntity : class
    {
        IEnumerable<TViewModel> Filtrar(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TViewModel> Todos();
        TViewModel Incluir(TViewModel model);
        TViewModel Atualizar(TViewModel model);
        void Remover(TViewModel model);
    }
}
