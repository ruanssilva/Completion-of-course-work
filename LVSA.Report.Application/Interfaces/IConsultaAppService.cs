using LVSA.Report.Application.ViewModels;
using LVSA.Report.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Application.Interfaces
{
    public interface IConsultaAppService : IAppServiceBase<ConsultaViewModel, Consulta>
    {
        ConsultaViewModel ObterPorId(int id);
    }
}
