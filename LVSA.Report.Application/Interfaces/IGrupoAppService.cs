using LVSA.Report.Application.ViewModels;
using LVSA.Report.Domain;

namespace LVSA.Report.Application.Interfaces
{
    public interface IGrupoAppService : IAppServiceBase<GrupoViewModel,Grupo>
    {
        GrupoViewModel ObterPorId(int id);
    }
}
