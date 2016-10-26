using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Domain;

namespace LVSA.Housing.Application.Interfaces
{
    public interface IMultaAppService : IAppServiceBase<MultaViewModel,Multa>
    {
        MultaViewModel ObterPorId(int id);
    }
}
