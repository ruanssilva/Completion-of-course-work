using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain.Interfaces.Repository.ReadOnly;
using LVSA.Base.Domain.Interfaces.Services;

namespace LVSA.Base.Domain.Services
{
    public class ReadOnlyService : IReadOnlyService
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        public ReadOnlyService(IReadOnlyRepository readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
        }

        public IEnumerable<TEntity> Query<TEntity>(string tsql)
        {
            return _readOnlyRepository.Query<TEntity>(tsql);
        }
    }
}
