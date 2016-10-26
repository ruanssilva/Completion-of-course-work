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
    public class PrescricaoAppService : AppServiceBase<PrescricaoViewModel, Prescricao, IPrescricaoService>, IPrescricaoAppService
    {
        public PrescricaoAppService(IPrescricaoService prescricaoService)
            : base(prescricaoService)
        {

        }

        public override IEnumerable<PrescricaoViewModel> Todos()
        {
            return Filtrar(f => true);
        }
    }
}
