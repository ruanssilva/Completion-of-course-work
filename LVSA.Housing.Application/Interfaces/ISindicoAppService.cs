using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Domain;

namespace LVSA.Housing.Application.Interfaces
{
    public interface ISindicoAppService : IAppServiceBase<SindicoViewModel,Sindico>
    {
        SindicoViewModel ObterPorId(int id);
    }
}
