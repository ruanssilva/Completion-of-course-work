using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Domain;

namespace LVSA.Security.Application.Interfaces
{
    public interface IRecursoAppService : IAppServiceBase<RecursoViewModel, Recurso>
    {
        string Export(IEnumerable<RecursoViewModel> model);
    }
}
