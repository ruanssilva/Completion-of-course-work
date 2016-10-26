using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using LVSA.Global.Domain;
using LVSA.Global.Domain.Interfaces.Services;

namespace LVSA.Global.Application
{
    public class TitulacaoAppService : AppServiceBase<TitulacaoViewModel, Titulacao, ITitulacaoService>, ITitulacaoAppService
    {
        public TitulacaoAppService(ITitulacaoService titulacaoService)
            : base(titulacaoService)
        {

        }

        public override System.Collections.Generic.IEnumerable<TitulacaoViewModel> Todos()
        {
            return Filtrar(f => true);
        }
    }
}
