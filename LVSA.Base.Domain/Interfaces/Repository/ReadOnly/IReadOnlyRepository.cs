using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Base.Domain.Interfaces.Repository.ReadOnly
{
    public interface IReadOnlyRepository
    {
        IEnumerable<TEntity> Query<TEntity>(string tsql);
    }
}
