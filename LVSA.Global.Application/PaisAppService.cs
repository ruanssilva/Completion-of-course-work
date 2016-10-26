using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using LVSA.Global.Domain;
using LVSA.Global.Domain.Interfaces.Services;

namespace LVSA.Global.Application
{
    public class PaisAppService : AppServiceBase<PaisViewModel, Pais, IPaisService>, IPaisAppService
    {
        public PaisAppService(IPaisService paisService)
            : base(paisService)
        {

        }

        public override System.Collections.Generic.IEnumerable<PaisViewModel> Todos()
        {
            return Filtrar(f => true);
        }
    }
}
