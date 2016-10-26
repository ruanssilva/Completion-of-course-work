using LVSA.Base.Presentation.App_Start;
using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using LVSA.Security.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace LVSA.Global.Presentation.Controllers
{
    public class ControllerBase : LVSA.Base.Presentation.Controllers.AutenticaController
    {
        private readonly IImagemAppService _imagemAppService;

        public ControllerBase()
        {
            _imagemAppService = NinjectWebCommon.Kernel.Get<IImagemAppService>();
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _imagemAppService.SetSeguranca(Contexto.Seguranca);
        }

        public ActionResult Imagem(int id)
        {
            try
            {
                ImagemViewModel imagem = _imagemAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                if (imagem != null)
                    return File(imagem.Valor, imagem.ContentType);
            }
            catch
            {

            }

            return HttpNotFound();
        }
    }
}
