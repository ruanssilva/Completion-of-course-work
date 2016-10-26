using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using LVSA.Global.Domain;
using LVSA.Global.Domain.Interfaces.Services;

namespace LVSA.Global.Application
{
    public class RacaCorAppService : AppServiceBase<RacaCorViewModel, RacaCor, IRacaCorService>, IRacaCorAppService
    {
        public RacaCorAppService(IRacaCorService racaCorService)
            : base(racaCorService)
        {

        }

        public override System.Collections.Generic.IEnumerable<RacaCorViewModel> Todos()
        {
            return Filtrar(f => true);
        }
    }
}
