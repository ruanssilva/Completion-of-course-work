using LVSA.Financial.Application.Interfaces;
using LVSA.Financial.Application.ViewModels;
using LVSA.Financial.Domain;
using LVSA.Financial.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Financial.Application
{
    public class ContaAppService : AppServiceBase<ContaViewModel, Conta, IContaService>, IContaAppService
    {
        public ContaAppService(IContaService contaService)
            : base(contaService)
        {

        }

        public ContaViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }

    }
}
