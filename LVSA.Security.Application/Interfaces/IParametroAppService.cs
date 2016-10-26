using LVSA.Security.Application.ViewModels;
using LVSA.Security.Domain;

namespace LVSA.Security.Application.Interfaces
{
    public interface IParametroAppService : IAppServiceBase<ParametroViewModel,Parametro>
    {
        ParametroViewModel ObterPorId(int id);
    }
}
