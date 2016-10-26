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
    public class ParametroAppService : AppServiceBase<ParametroViewModel, Parametro, IParametroService>, IParametroAppService
    {
        public ParametroAppService(IParametroService parametroService)
            : base(parametroService)
        {

        }

        public override IEnumerable<ParametroViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public ParametroViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }
    }
}
