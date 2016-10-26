using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Domain;
using LVSA.Security.Domain.Interfaces.Services;

namespace LVSA.Security.Application
{
    public class ColigadaAppService : AppServiceBase<ColigadaViewModel, Coligada, IColigadaService>, IColigadaAppService
    {
        public ColigadaAppService(IColigadaService coligadaService)
            : base(coligadaService)
        {

        }

        public override IEnumerable<ColigadaViewModel> Todos()
        {
            return Filtrar(f => true);
        }
    }
}
