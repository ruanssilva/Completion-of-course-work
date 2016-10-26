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
    public class TipoUsuarioAppService : AppServiceBase<TipoUsuarioViewModel,TipoUsuario,ITipoUsuarioService>, ITipoUsuarioAppService
    {
        public TipoUsuarioAppService(ITipoUsuarioService tipoUsuarioService)
            : base(tipoUsuarioService)
        {

        }
    }
}
