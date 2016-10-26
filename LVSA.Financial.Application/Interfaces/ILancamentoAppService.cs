using LVSA.Financial.Application.ViewModels;
using LVSA.Financial.Domain;

namespace LVSA.Financial.Application.Interfaces
{
    public interface ILancamentoAppService : IAppServiceBase<LancamentoViewModel,Lancamento>
    {
        LancamentoViewModel ObterPorId(int id);
    }
}
