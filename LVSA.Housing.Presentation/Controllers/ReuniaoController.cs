

using LVSA.Base.Presentation.ViewModels;
using LVSA.Global.Application.Interfaces;
using LVSA.Housing.Application.Interfaces;
using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Presentation.ViewModels;
using LVSA.Security.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Housing.Presentation.Controllers
{
    public class ReuniaoController : SindicoControllerBase
    {
        private readonly IReuniaoAppService _reuniaoAppService;
        private readonly IPessoaFisicaComplementoAppService _pessoaFisicaComplementoAppService;
        private readonly IMoradorAppService _moradorAppService;

        public ReuniaoController(IReuniaoAppService reuniaoAppService, IPessoaFisicaComplementoAppService pessoaFisicaComplementoAppService, IMoradorAppService moradorAppService)
        {
            _reuniaoAppService = reuniaoAppService;
            _pessoaFisicaComplementoAppService = pessoaFisicaComplementoAppService;
            _moradorAppService = moradorAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (Contexto.IsAuthentication())
            {
                _reuniaoAppService.SetSeguranca(Contexto.Seguranca);
                _moradorAppService.SetSeguranca(Contexto.Seguranca);
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Sindico == null)
            {
                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Você não é um sindico.",
                    Message = "Essa área no sistema é exclusiva para sindicos, procure o administrador para mais informações.",
                    Center = true,
                    Sticky = true,
                    Style = GritterStyle.Warning,
                });

                filterContext.Result = RedirectToAction("Index", "Home");
            }
        }

        // GET: Reuniao
        public ActionResult Index()
        {
            try
            {
                IEnumerable<ReuniaoViewModel> model = _reuniaoAppService.Filtrar(f => f.SindicoId == Sindico.Id);

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Reuniao/Details/5
        public ActionResult Details(long id)
        {
            try
            {
                ReuniaoViewModel model = _reuniaoAppService.Filtrar(f => f.Id == id && f.SindicoId == Sindico.Id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Reuniao/Presenca/5
        public ActionResult Ata(long id)
        {
            try
            {
                ReuniaoViewModel model = _reuniaoAppService.Filtrar(f => f.Id == id && f.SindicoId == Sindico.Id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Reuniao/Presenca/5
        [HttpPost]
        public ActionResult Ata(long id, AtaViewModel ata)
        {
            try
            {
                ReuniaoViewModel model = _reuniaoAppService.Filtrar(f => f.Id == id && f.SindicoId == Sindico.Id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                model.Ata = ata.AtaCliente;
                                
                _reuniaoAppService.Ata(model);

                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Sucesso!",
                    Message = "Operação realizada com sucesso.",
                    Style = GritterStyle.Success,
                });

            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Reuniao/Presenca/5
        public ActionResult Presenca(long id)
        {
            try
            {
                ReuniaoViewModel model = _reuniaoAppService.Filtrar(f => f.Id == id && f.SindicoId == Sindico.Id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                ViewBag.MoradorSet = _moradorAppService.Filtrar(f => f.Moradia.Bloco.SindicoId == Sindico.Id).ToList();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Reuniao/Presenca/5
        [HttpPost]
        public ActionResult Presenca(long id, long[] PresencaSet)
        {
            try
            {
                ReuniaoViewModel model = _reuniaoAppService.Filtrar(f => f.Id == id && f.SindicoId == Sindico.Id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                model.PresencaSet = PresencaSet;                

                _reuniaoAppService.Presenca(model);

                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Sucesso!",
                    Message = "Operação realizada com sucesso.",
                    Style = GritterStyle.Success,
                });

            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Reuniao/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Reuniao/Create
        [HttpPost]
        public ActionResult Create(ReuniaoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                model.SindicoId = Sindico.Id;

                _reuniaoAppService.Incluir(model);

                List<int> PessoaIds = Sindico.Blocos.SelectMany(s => s.Moradias.SelectMany(sm => sm.Moradores)).Select(s => s.PessoaId).ToList();
                List<int> UsuarioIds = _pessoaFisicaComplementoAppService.Filtrar(f => PessoaIds.Contains(f.PessoaId) && f.UsuarioId != null).Select(s => (int)s.UsuarioId).ToList();

        
                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Sucesso!",
                    Message = "Operação realizada com sucesso.",
                    Style = GritterStyle.Success,
                });

            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Reuniao/Edit/5
        public ActionResult Edit(long id)
        {
            try
            {
                ReuniaoViewModel model = _reuniaoAppService.Filtrar(f => f.Id == id && f.SindicoId == Sindico.Id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Reuniao/Edit/5
        [HttpPost]
        public ActionResult Edit(long id, ReuniaoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                model.SindicoId = Sindico.Id;

                _reuniaoAppService.Atualizar(model);

                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Sucesso!",
                    Message = "Operação realizada com sucesso.",
                    Style = GritterStyle.Success,
                });
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Reuniao/Delete/5
        public ActionResult Delete(long id)
        {
            try
            {
                ReuniaoViewModel model = _reuniaoAppService.Filtrar(f => f.Id == id && f.SindicoId == Sindico.Id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Reuniao/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, ReuniaoViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _reuniaoAppService.Filtrar(f => f.Id == id && f.SindicoId == Sindico.Id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _reuniaoAppService.Remover(model);

                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Sucesso!",
                    Message = "Operação realizada com sucesso.",
                    Style = GritterStyle.Success,
                });
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }
    }
}
