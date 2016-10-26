using LVSA.Base.Domain.Services;
using LVSA.Housing.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Domain.Interfaces.Repository;
using LVSA.Housing.Domain.Interfaces.Repository;

namespace LVSA.Housing.Domain.Services
{
    public class PresencaService : ServiceBase<Presenca>, IPresencaService
    {
        public PresencaService(IPresencaRepository presencaRepository)
            : base(presencaRepository)
        {
        }
    }
}
