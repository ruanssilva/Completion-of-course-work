using LVSA.Base.Domain.Services;
using LVSA.Report.Domain.Interfaces.Repository;
using LVSA.Report.Domain.Interfaces.Services;

namespace LVSA.Report.Domain.Services
{

    public class ConsultaService : ServiceBase<Consulta>, IConsultaService
    {
        public ConsultaService(IConsultaRepository consultaRepository)
            : base(consultaRepository)
        {
        }
    }
}
