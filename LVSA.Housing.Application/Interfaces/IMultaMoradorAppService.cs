using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Domain;

namespace LVSA.Housing.Application.Interfaces
{
    public interface IMultaMoradorAppService : IAppServiceBase<MultaMoradorViewModel, MultaMorador>
    {
        MultaMoradorViewModel ObterPorId(int id);
    }
}
