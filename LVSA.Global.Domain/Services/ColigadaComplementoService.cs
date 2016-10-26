using LVSA.Base.Domain.Services;
using LVSA.Global.Domain.Interfaces.Repository;
using LVSA.Global.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Global.Domain.Services
{
    public class ColigadaComplementoService : ServiceBase<ColigadaComplemento>, IColigadaComplementoService
    {
        private readonly IColigadaComplementoRepository _repository;
        public ColigadaComplementoService(IColigadaComplementoRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
