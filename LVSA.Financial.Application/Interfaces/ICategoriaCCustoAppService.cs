using LVSA.Financial.Application.ViewModels;
using LVSA.Financial.Domain;

namespace LVSA.Financial.Application.Interfaces
{
    public interface ICategoriaCCustoAppService : IAppServiceBase<CategoriaCCustoViewModel,CategoriaCCusto>
    {
        CategoriaCCustoViewModel ObterPorId(int id);
    }
}
