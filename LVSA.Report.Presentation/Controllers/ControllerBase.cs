
using LVSA.Base.Presentation.App_Start;
using LVSA.Report.Application.Interfaces;
using LVSA.Report.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Ninject.Web.Common;
using LVSA.Report.Presentation.Models;

namespace LVSA.Report.Presentation.Controllers
{
    public class ControllerBase : LVSA.Base.Presentation.Controllers.AutenticaController
    {
        protected readonly IGrupoAppService _grupoAppService;
        protected readonly IUsuarioGrupoAppService _usuarioGrupoAppService;

        public ControllerBase()
        {
            _grupoAppService = LVSA.Base.Presentation.App_Start.NinjectWebCommon.Kernel.Get<IGrupoAppService>();
            _usuarioGrupoAppService = LVSA.Base.Presentation.App_Start.NinjectWebCommon.Kernel.Get<IUsuarioGrupoAppService>();
        }


        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _grupoAppService.SetSeguranca(Contexto.Seguranca);
            _usuarioGrupoAppService.SetSeguranca(Contexto.Seguranca);
        }

        private IEnumerable<GrupoViewModel> _grupoSet
        {
            get
            {
                return GetCache<IEnumerable<GrupoViewModel>>("!@#grupo" + Contexto.Seguranca.CODUSUARIO);
            }
            set
            {
                SetCache<IEnumerable<GrupoViewModel>>(value, "!@#grupo" + Contexto.Seguranca.CODUSUARIO);
            }
        }
        protected IEnumerable<GrupoViewModel> GrupoSet
        {
            get
            {
                if (Contexto.IsAuthentication())
                {
                    int[] todos = _usuarioGrupoAppService.Filtrar(f => f.UsuarioId == Contexto.Seguranca.Usuario.Id).Select(s => s.GrupoId).ToArray();
                    _grupoSet = _grupoAppService.Filtrar(f => todos.Contains(f.Id)).ToList();
                }

                return _grupoSet;
            }
        }

        protected IEnumerable<CuboViewModel> CuboSet
        {
            get
            {
                if (GrupoSet != null && GrupoSet.SelectMany(sm => sm.Cubos).Count() > 0)
                    return GrupoSet.SelectMany(sm => sm.Cubos);
                return null;
            }
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Contexto.Seguranca != null && Contexto.Seguranca.FilialId > 0 && Contexto.Seguranca.ColigadaId > 0 && Contexto.Seguranca.CODUSUARIO != null/* && (SegurancaReport.Grupos == null)*/)
            {
                //SegurancaReport = new SegurancaApp { Id = Seguranca.Id };

                //List<int> GrupoIds = _usuarioGrupoAppService.Filtrar(f => f.UsuarioId == Seguranca.UsuarioId).Select(s => s.GrupoId).ToList();
                //SegurancaReport.Grupos = _grupoAppService.Filtrar(f => GrupoIds.Contains(f.Id)).ToList();
            }
        }

    }
}