using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LVSA.Base.Application.Exceptions;
using LVSA.Noticia.Application.Interfaces;
using LVSA.Noticia.Application.ViewModels;

namespace LVSA.Security.Service.Controllers
{
    public class NoticiaController : AutenticaController
    {
        public readonly INoticiaAppService _noticiaAppService;

        public NoticiaController(INoticiaAppService noticiaAppService)
        {
            _noticiaAppService = noticiaAppService;
        }

        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            _noticiaAppService.SetSeguranca(Seguranca);

            if (_noticias == null)
                _noticias = _noticiaAppService.Filtrar(w => w.Ativo && w.PublicadoEm <= DateTime.Now && w.ExpiraEm >= DateTime.Now);
        }

        private IEnumerable<NoticiaViewModel> _noticias
        {
            get
            {
                return GetCache<IEnumerable<NoticiaViewModel>>("#_noticias");
            }
            set
            {
                SetCache<IEnumerable<NoticiaViewModel>>(value, "#_noticias");
            }
        }

        public IEnumerable<NoticiaViewModel> Noticias
        {
            get
            {
                return _noticias ?? new List<NoticiaViewModel> { };
            }
            set
            {
                _noticias = value;
            }
        }

        // GET: api/Noticia
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Noticias.Where(w => w.AplicacaoIdSet.Contains((int)(Seguranca.AplicacaoId ?? 0))));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/Noticia/5
        public HttpResponseMessage Get(long id)
        {
            try
            {
                var noticia = Noticias.Where(w => w.AplicacaoIdSet.Contains((int)Seguranca.AplicacaoId) && w.Id == id && w.Ativo).SingleOrDefault();
                if (noticia == null)
                    throw new NoRecordsFoundException("Registro não encontrado");

                if (!noticia.UsuarioIdSet.Contains(Seguranca.Usuario.Id))
                    _noticiaAppService.Visualiza(noticia, Seguranca.Usuario);

                return Request.CreateResponse(HttpStatusCode.OK, noticia);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Post()
        {
            try
            {
                _noticias = null;

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
