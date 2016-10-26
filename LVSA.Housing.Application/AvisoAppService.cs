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
    public class AvisoAppService : AppServiceBase<AvisoViewModel, Aviso, IAvisoService>, IAvisoAppService
    {
        public AvisoAppService(IAvisoService avisoService)
            : base(avisoService)
        {

        }
    }
}
