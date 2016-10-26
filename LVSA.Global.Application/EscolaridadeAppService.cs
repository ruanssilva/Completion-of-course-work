
using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using LVSA.Global.Domain;
using LVSA.Global.Domain.Interfaces.Services;
namespace LVSA.Global.Application
{
    public class EscolaridadeAppService : AppServiceBase<EscolaridadeViewModel,Escolaridade,IEscolaridadeService>, IEscolaridadeAppService
    {
        public EscolaridadeAppService(IEscolaridadeService escolaridadeService)
            :base(escolaridadeService)
        {
                
        }

        public override System.Collections.Generic.IEnumerable<EscolaridadeViewModel> Todos()
        {
            return Filtrar(f => true);
        }
    }
}
