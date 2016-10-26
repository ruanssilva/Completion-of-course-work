using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Base.Domain.Interfaces.Repository.ReadOnly
{
    public interface IReadOnlyRepositoryBase<TEntity>
       where TEntity : class
    {
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
    }

}
