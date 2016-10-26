using LVSA.Farm.Application.ViewModels;
using LVSA.Farm.Domain;

namespace LVSA.Farm.Application.Interfaces
{
    public interface ITerrenoAppService : IAppServiceBase<TerrenoViewModel,Terreno>
    {
        TerrenoViewModel Obter();
    }
}
