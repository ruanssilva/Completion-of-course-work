using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Base.Application.Interfaces
{
    public interface IReadOnlyAppService
    {
        IEnumerable<TEntity> Query<TEntity>(string tsql);
    }
}
