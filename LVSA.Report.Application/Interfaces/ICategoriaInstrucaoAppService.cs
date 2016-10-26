using LVSA.Report.Application.ViewModels;
using LVSA.Report.Domain;

namespace LVSA.Report.Application.Interfaces
{
    public interface ICategoriaInstrucaoAppService : IAppServiceBase<CategoriaInstrucaoViewModel,CategoriaInstrucao>
    {
        CategoriaInstrucaoViewModel ObterPorId(int id);
    }
}
