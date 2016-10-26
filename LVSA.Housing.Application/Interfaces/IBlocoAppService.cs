using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Domain;

namespace LVSA.Housing.Application.Interfaces
{
    public interface IBlocoAppService : IAppServiceBase<BlocoViewModel,Bloco>
    {
        BlocoViewModel ObterPorId(int id);
    }
}
