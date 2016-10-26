using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Domain;

namespace LVSA.Security.Application.Interfaces
{
    public interface ITipoRecursoAppService : IAppServiceBase<TipoRecursoViewModel,TipoRecurso>
    {
        TipoRecursoViewModel ObterPorId(short id);
    }
}
