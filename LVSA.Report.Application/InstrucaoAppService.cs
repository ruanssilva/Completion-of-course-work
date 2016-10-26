using LVSA.Report.Application.Interfaces;
using LVSA.Report.Application.ViewModels;
using LVSA.Report.Domain;
using LVSA.Report.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Application
{
    public class InstrucaoAppService : AppServiceBase<InstrucaoViewModel,Instrucao,IInstrucaoService>, IInstrucaoAppService
    {
        public InstrucaoAppService(IInstrucaoService instrucaoService)
            : base(instrucaoService)
        {
            
        }

        public override IEnumerable<InstrucaoViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public InstrucaoViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }
    }
}
