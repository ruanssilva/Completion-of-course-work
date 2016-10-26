using LVSA.Financial.Domain.Interfaces.Repository;
using LVSA.Financial.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Financial.Domain.Services
{
    public class ContaService : ServiceBase<Conta>, IContaService
    {
        public ContaService(IContaRepository contaRepository)
            : base(contaRepository)
        {

        }
    }
}
