using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using LVSA.Global.Domain;
using LVSA.Global.Domain.Interfaces.Services;

namespace LVSA.Global.Application
{
    public class FilialComplementoAppService : AppServiceBase<FilialComplementoViewModel,FilialComplemento,IFilialComplementoService>, IFilialComplementoAppService
    {
        public FilialComplementoAppService(IFilialComplementoService filialComplementoService)
            :base(filialComplementoService)
        {

        }
    }
}
