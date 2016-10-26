using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Domain;
using LVSA.Security.Domain.Interfaces.Services;

namespace LVSA.Security.Application
{
    public class TipoRecursoAppService : AppServiceBase<TipoRecursoViewModel, TipoRecurso, ITipoRecursoService>, ITipoRecursoAppService
    {
        public TipoRecursoAppService(ITipoRecursoService tipoRecursoService)
            : base(tipoRecursoService)
        {

        }

        public override IEnumerable<TipoRecursoViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public TipoRecursoViewModel ObterPorId(short id)
        {
            return Filtrar(f => f.Id == id).FirstOrDefault();
        }
    }
}
