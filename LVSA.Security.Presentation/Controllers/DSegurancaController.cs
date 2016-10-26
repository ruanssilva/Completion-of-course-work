using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LVSA.Base.Application.Exceptions;
using LVSA.Base.Presentation.Rest;
using LVSA.Security.Application.Models;
using LVSA.Security.Presentation.Rest;

namespace LVSA.Security.Presentation.Controllers
{
    public class DSegurancaController : ControllerBase
    {
        private DSegurancaRest _dSegurancaRest;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _dSegurancaRest = new DSegurancaRest(Token);
        }

        // GET: DSeguranca
        public ActionResult Index()
        {
            try
            {
                var segurancas = _dSegurancaRest.Get();

                List<Seguranca> model = new List<Seguranca>();
                foreach (var x in segurancas)
                    model.Add(((JObject)x).ToObject<Seguranca>());

                ViewBag.Logs = new DLogRest(Token).Get(); ;

                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Index(bool Reniciar)
        {
            try
            {
                if (Reniciar)
                {
                    //GGritterHub.Invoke("Information", "", "Atenção!", "Uma atualização no servidores está ocorrendo agora e o serviço pode ficar lento por alguns instantes.");
                    _dSegurancaRest.Post();
                }
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return Index();
        }

        public ActionResult Details(long id)
        {
            try
            {
                var seguranca = _dSegurancaRest.Get(id);
                ViewBag.Seguranca = ((JObject)seguranca).ToObject<Seguranca>();
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return Index();
        }

        public ActionResult Send(int? id = null)
        {
            try
            {
                if (id == null)
                    ViewBag.Send = "";
                else
                {
                    var aplicacoes = _aplicacaoRest.Get();
                    if (aplicacoes.Where(w => w.Id == id).Count() == 0)
                        throw new NoRecordsFoundException("Aplicação não encontrada");
                    ViewBag.Send = aplicacoes.Where(w => w.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return Index();
        }

        [HttpPost]
        public ActionResult Send(int? id, string message)
        {
            try
            {
                if (id == null)
                    throw new NoRecordsFoundException("Aplicação não encontrada");

                string server = null;

                if (id == 0)
                    server = System.Web.Configuration.WebConfigurationManager.AppSettings["Address_SignalR"];
                else
                {
                    var aplicacoes = _aplicacaoRest.Get();
                    server = aplicacoes.Where(w => w.Id == id).Select(s => s.Link).FirstOrDefault();
                }

                var connection = new HubConnection(server, new Dictionary<string, string> { { "token", Token } });
                var hub = connection.CreateHubProxy("GritterHub");

                connection.Start().Wait();

                hub.Invoke("Information", "#Chamando todos", message);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return Index();
        }
    }
}