using LVSA.Financial.Application.ViewModels;
using LVSA.Financial.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Financial.Application.Interfaces
{
    public interface IContaAppService : IAppServiceBase<ContaViewModel,Conta>
    {
        ContaViewModel ObterPorId(int id);
    }
}
