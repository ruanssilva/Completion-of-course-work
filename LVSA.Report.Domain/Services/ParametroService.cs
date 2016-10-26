using LVSA.Base.Domain.Services;
using LVSA.Report.Domain.Interfaces.Repository;
using LVSA.Report.Domain.Interfaces.Services;

namespace LVSA.Report.Domain.Services
{
    public class ParametroService : ServiceBase<Parametro>, IParametroService
    {

        public ParametroService(IParametroRepository parametroRepository)
            : base(parametroRepository)
        {
        }
    }
}
