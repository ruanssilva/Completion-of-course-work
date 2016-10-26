using LVSA.Base.Domain.Services;
using LVSA.Report.Domain.Interfaces.Repository;
using LVSA.Report.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Domain.Services
{
    public class ConsultaParametroService: ServiceBase<ConsultaParametro>, IConsultaParametroService
    {

        public ConsultaParametroService(IConsultaParametroRepository consultaParametroRepository)
            : base(consultaParametroRepository)
        {
        }
    }
}
