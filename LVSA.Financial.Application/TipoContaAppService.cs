using LVSA.Financial.Application.Interfaces;
using LVSA.Financial.Application.ViewModels;
using LVSA.Financial.Domain;
using LVSA.Financial.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Financial.Application
{
    public class TipoContaAppService : AppServiceBase<TipoContaViewModel, TipoConta, ITipoContaService>, ITipoContaAppService
    {
        public TipoContaAppService(ITipoContaService tipoContaService)
            : base(tipoContaService)
        {

        }

        public override IEnumerable<TipoContaViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public TipoContaViewModel ObterPorId(short id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }
    }
}
