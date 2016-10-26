using LVSA.Financial.Application.ViewModels;
using LVSA.Financial.Domain;

namespace LVSA.Financial.Application.Interfaces
{
    public interface INFiscalAppService : IAppServiceBase<NFiscalViewModel,NFiscal>
    {
        NFiscalViewModel ObterPorId(int id);
    }
}
