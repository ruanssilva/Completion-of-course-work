using LVSA.Housing.Application.Interfaces;
using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Domain;
using LVSA.Housing.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Application
{
    public class CondominioAppService : AppServiceBase<CondominioViewModel, Condominio, ICondominioService>, ICondominioAppService
    {
        public CondominioAppService(ICondominioService condominioService)
            : base(condominioService)
        {

        }

        public CondominioViewModel Obter()
        {
            return Filtrar(f => f.ColigadaId == Seguranca.ColigadaId && f.FilialId == Seguranca.FilialId).SingleOrDefault();
        }
    }
}
