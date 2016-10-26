using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using LVSA.Global.Domain;
using LVSA.Global.Domain.Interfaces.Services;

namespace LVSA.Global.Application
{
    public class ColigadaComplementoAppService : AppServiceBase<ColigadaComplementoViewModel, ColigadaComplemento, IColigadaComplementoService>, IColigadaComplementoAppService
    {
        public ColigadaComplementoAppService(IColigadaComplementoService coligadaComplementoService)
            : base(coligadaComplementoService)
        {

        }
    }
}
