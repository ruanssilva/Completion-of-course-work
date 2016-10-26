using LVSA.Base.Domain.Services;
using LVSA.Report.Domain.Interfaces.Repository;
using LVSA.Report.Domain.Interfaces.Services;

namespace LVSA.Report.Domain.Services
{
    public class InstrucaoService : ServiceBase<Instrucao>, IInstrucaoService
    {

        public InstrucaoService(IInstrucaoRepository instrucaoRepository)
            : base(instrucaoRepository)
        {
        }
    }
}
