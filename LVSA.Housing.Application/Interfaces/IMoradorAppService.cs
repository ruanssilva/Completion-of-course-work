using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Domain;

namespace LVSA.Housing.Application.Interfaces
{
    public interface IMoradorAppService : IAppServiceBase<MoradorViewModel,Morador>
    {
        MoradorViewModel ObterPorId(int id);
    }
}
