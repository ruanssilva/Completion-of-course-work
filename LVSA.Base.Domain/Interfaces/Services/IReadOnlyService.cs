using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Base.Domain.Interfaces.Services
{
    public interface IReadOnlyService
    {
        IEnumerable<TEntity> Query<TEntity>(string tsql);
    }
}
