using LVSA.Report.Application.ViewModels;
using LVSA.Report.Domain;

namespace LVSA.Report.Application.Interfaces
{
    public interface ICategoriaCuboAppService : IAppServiceBase<CategoriaCuboViewModel,CategoriaCubo>
    {
        CategoriaCuboViewModel ObterPorId(int id);
    }
}
