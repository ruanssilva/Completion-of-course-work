using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.Models;
using LVSA.Base.Presentation.App_Start;
using Ninject;
using Ninject.Web.Common;

namespace LVSA.Security.Presentation.Controllers
{
    public abstract class FiltroController : ControllerBase
    {
        private object _fFilialId
        {
            get
            {
                return GetCache<object>(Token + "LVSA.Security.Presentation.FiltroController#FFilialId");
            }
            set
            {
                SetCache<object>(value, Token + "LVSA.Security.Presentation.FiltroController#FFilialId");
            }
        }

        protected short? FFilialId
        {
            get
            {
                return (short?)_fFilialId;
            }
            set
            {
                _fFilialId = value;
            }
        }




        protected long? FCODUSUARIO
        {
            get
            {
                return (long?)GetCache<object>(Token + "LVSA.Security.Presentation.FiltroController#FCODUSUARIO");
            }
            set
            {
                SetCache<object>(value, Token + "LVSA.Security.Presentation.FiltroController#FCODUSUARIO");
            }
        }

        private object _fgrupoid
        {
            get
            {
                return GetCache<object>(Token + "LVSA.Security.Presentation.FiltroController#FGrupoId");
            }
            set
            {
                SetCache<object>(value, Token + "LVSA.Security.Presentation.FiltroController#FGrupoId");
            }
        }

        protected long? FGrupoId
        {
            get
            {
                return (long?)_fgrupoid;
            }
            set
            {
                _fgrupoid = value;
            }
        }

        private object _faplicacaoid
        {
            get
            {
                return GetCache<object>(Token + "LVSA.Security.Presentation.FiltroController#FAplicacaoId");
            }
            set
            {
                SetCache<object>(value, Token + "LVSA.Security.Presentation.FiltroController#FAplicacaoId");
            }
        }

        protected int? FAplicacaoId
        {
            get
            {
                return (int?)_faplicacaoid;
            }
            set
            {
                _faplicacaoid = value;
            }
        }

        protected readonly IUsuarioAppService _usuarioAppService;
        protected readonly IAplicacaoAppService _aplicacaoAppService;
        protected readonly IContextoAppService _contextoAppService;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _usuarioAppService.SetSeguranca(Contexto.Seguranca);
            _aplicacaoAppService.SetSeguranca(Contexto.Seguranca);
            _contextoAppService.SetSeguranca(Contexto.Seguranca);

            if (Contexto.Seguranca.FilialSet.Count() == 1)
                FFilialId = Contexto.Seguranca.FilialSet.Single().Id;
            ViewBag.FilialSet = Contexto.Seguranca.FilialSet;

            if (requestContext.HttpContext.Request.Form["FilialId"] != null && !string.IsNullOrWhiteSpace(requestContext.HttpContext.Request.Form["FilialId"]))
            {
                FFilialId = Convert.ToInt16(requestContext.HttpContext.Request.Form["FilialId"]);
            }
                        

            if (FFilialId == null)
                ModelState.AddModelError("FilialId", "Informe a filial para o filtro");


            FAplicacaoId = requestContext.HttpContext.Request.Form["AplicacaoId"] != null ? (!string.IsNullOrWhiteSpace(requestContext.HttpContext.Request.Form["AplicacaoId"]) ? Convert.ToInt16(requestContext.HttpContext.Request.Form["AplicacaoId"]) : (int?)null) : FAplicacaoId;
            FCODUSUARIO = requestContext.HttpContext.Request.Form["CODUSUARIO"] != null ? (!string.IsNullOrWhiteSpace(requestContext.HttpContext.Request.Form["CODUSUARIO"]) ? Convert.ToInt64(requestContext.HttpContext.Request.Form["CODUSUARIO"]) : FCODUSUARIO) : FCODUSUARIO;
        }

        public FiltroController()
        {
            _usuarioAppService = NinjectWebCommon.RegisterServices().Get<IUsuarioAppService>();
            _aplicacaoAppService = NinjectWebCommon.RegisterServices().Get<IAplicacaoAppService>();
            _contextoAppService = NinjectWebCommon.RegisterServices().Get<IContextoAppService>();
        }
    }
}