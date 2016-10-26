using LVSA.Financial.Application.ViewModels;
using LVSA.Financial.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Financial.Application.Interfaces
{
    public interface ITipoContaAppService : IAppServiceBase<TipoContaViewModel,TipoConta>
    {
        TipoContaViewModel ObterPorId(short id);
    }
}
