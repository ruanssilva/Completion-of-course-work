using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using LVSA.Global.Domain;
using LVSA.Global.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace LVSA.Global.Application
{
    public class BairroAppService : AppServiceBase<BairroViewModel,Bairro,IBairroService>, IBairroAppService
    {
        public BairroAppService(IBairroService bairroService)
            : base(bairroService)
        {

        }

        public override IEnumerable<BairroViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public BairroViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }

    }
}
