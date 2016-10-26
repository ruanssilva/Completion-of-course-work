using LVSA.Farm.Application.Interfaces;
using LVSA.Farm.Application.ViewModels;
using LVSA.Farm.Domain;
using LVSA.Farm.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Application
{
    public class LocalPesagemAppService : AppServiceBase<LocalPesagemViewModel, LocalPesagem, ILocalPesagemService>, ILocalPesagemAppService
    {
        public LocalPesagemAppService(ILocalPesagemService localPesagemService)
            : base(localPesagemService)
        {

        }

        public override IEnumerable<LocalPesagemViewModel> Todos()
        {
            return Filtrar(f => f.Ativo);
        }
    }
}
