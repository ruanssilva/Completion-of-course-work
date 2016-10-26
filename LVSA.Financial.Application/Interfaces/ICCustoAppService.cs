using LVSA.Financial.Application.ViewModels;
using LVSA.Financial.Domain;

namespace LVSA.Financial.Application.Interfaces
{
    public interface ICCustoAppService : IAppServiceBase<CCustoViewModel,CCusto>
    {
        CCustoViewModel ObterPorId(int id);
    }
}
