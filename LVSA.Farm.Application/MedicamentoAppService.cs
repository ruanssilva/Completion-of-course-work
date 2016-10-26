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
    public class MedicamentoAppService : AppServiceBase<MedicamentoViewModel, Medicamento, IMedicamentoService>, IMedicamentoAppService
    {
        public MedicamentoAppService(IMedicamentoService medicamentoService)
            : base(medicamentoService)
        {

        }

        public override IEnumerable<MedicamentoViewModel> Todos()
        {
            return Filtrar(f => true);
        }
    }
}
