using LVSA.Report.Application.ViewModels;
using LVSA.Report.Domain;

namespace LVSA.Report.Application.Interfaces
{
    public interface IParametroAppService : IAppServiceBase<ParametroViewModel, Parametro>
    {
        ParametroViewModel ObterPorId(int id);
    }
}
