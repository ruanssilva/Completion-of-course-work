using LVSA.Financial.Domain.Interfaces.Repository;
using LVSA.Financial.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Financial.Domain.Services
{
    public class TipoContaService : ServiceBase<TipoConta>, ITipoContaService
    {
        public TipoContaService(ITipoContaRepository tipoContaRepository)
            : base(tipoContaRepository)
        {

        }
    }
}
