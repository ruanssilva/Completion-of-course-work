using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Application.Interfaces;
using LVSA.Base.Domain.Interfaces.Services;

namespace LVSA.Base.Application
{
    public class ReadOnlyAppService : IReadOnlyAppService
    {
        protected readonly IReadOnlyService _readOnlyService;
        public ReadOnlyAppService(IReadOnlyService readOnlyService)
        {
            _readOnlyService = readOnlyService;
        }

        public IEnumerable<TEntity> Query<TEntity>(string tsql)
        {
            return _readOnlyService.Query<TEntity>(tsql);
        }
    }
}
