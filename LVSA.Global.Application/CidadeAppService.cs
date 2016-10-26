using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using LVSA.Global.Domain;
using LVSA.Global.Domain.Interfaces.Services;

namespace LVSA.Global.Application
{
    public class CidadeAppService : AppServiceBase<CidadeViewModel, Cidade, ICidadeService>, ICidadeAppService
    {
        public CidadeAppService(ICidadeService cidadeService)
            : base(cidadeService)
        {

        }

        public override System.Collections.Generic.IEnumerable<CidadeViewModel> Todos()
        {
            return Filtrar(f => true);
        }
    }
}
