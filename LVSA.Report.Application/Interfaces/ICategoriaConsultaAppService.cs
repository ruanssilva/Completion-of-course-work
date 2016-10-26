using LVSA.Report.Application.ViewModels;
using LVSA.Report.Domain;

namespace LVSA.Report.Application.Interfaces
{
    public interface ICategoriaConsultaAppService : IAppServiceBase<CategoriaConsultaViewModel,CategoriaConsulta>
    {
        CategoriaConsultaViewModel ObterPorId(int id);
    }
}
