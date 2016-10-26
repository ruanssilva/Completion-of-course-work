using LVSA.Report.Application.ViewModels;
using LVSA.Report.Domain;

namespace LVSA.Report.Application.Interfaces
{
    public interface ICuboAppService : IAppServiceBase<CuboViewModel, Cubo>
    {
        CuboViewModel ObterPorId(int id);
    }
}
