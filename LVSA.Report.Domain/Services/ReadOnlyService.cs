//using LVSA.Base.Domain.Services;
//using LVSA.Report.Domain.Interfaces.Repository.ReadOnly;
//using LVSA.Report.Domain.Interfaces.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LVSA.Report.Domain.Services
//{
//    public class ReadOnlyService : IReadOnlyService
//    {
//        private readonly IReadOnlyRepository _readOnlyRepository;

//        public ReadOnlyService(IReadOnlyRepository readOnlyRepository)
//        {
//            _readOnlyRepository = readOnlyRepository;
//        }

//        public IEnumerable<TEntity> Query<TEntity>(string TSQL)
//        {
//            return _readOnlyRepository.Query<TEntity>(TSQL);
//        }
//    }
//}
