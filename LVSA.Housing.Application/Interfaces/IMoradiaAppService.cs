using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Domain;

namespace LVSA.Housing.Application.Interfaces
{
    public interface IMoradiaAppService : IAppServiceBase<MoradiaViewModel,Moradia>
    {
        MoradiaViewModel ObterPorId(int id);
    }
}
