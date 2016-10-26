using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Base.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity>
        where TEntity : class
    {
        void Add(TEntity obj);
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity obj);
        void Delete(TEntity obj);
    }
}
