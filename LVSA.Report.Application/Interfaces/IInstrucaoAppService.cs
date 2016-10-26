using LVSA.Report.Application.ViewModels;
using LVSA.Report.Domain;

namespace LVSA.Report.Application.Interfaces
{
    public interface IInstrucaoAppService : IAppServiceBase<InstrucaoViewModel, Instrucao>
    {
        InstrucaoViewModel ObterPorId(int id);
    }
}
