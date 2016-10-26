
using LVSA.Base.Presentation.ViewModels;
using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Global.Presentation.Controllers
{
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoAppService _estadoAppService;
        private readonly IPaisAppService _paisAppService;

        public EstadoController(IEstadoAppService estadoAppService, IPaisAppService paisAppService)
        {
            _estadoAppService = estadoAppService;
            _paisAppService = paisAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _estadoAppService.SetSeguranca(Contexto.Seguranca);

            ViewBag.PaisSet = _paisAppService.Todos();
        }

        // GET: Estado
        public ActionResult Index()
        {
            try
            {
                IEnumerable<EstadoViewModel> model = _estadoAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Estado/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                EstadoViewModel model = _estadoAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // GET: Estado/Create
        public ActionResult Create()
        {
            try
            {
                

                return View(new EstadoViewModel());
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Estado/Create
        [HttpPost]
        public ActionResult Create(EstadoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {


                    return View(model);
                }
                
                _estadoAppService.Incluir(model);

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

        // GET: Estado/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                EstadoViewModel model = _estadoAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // POST: Estado/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EstadoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                }
                
                _estadoAppService.Atualizar(model);

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

        // GET: Estado/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                EstadoViewModel model = _estadoAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
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

        // POST: Estado/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EstadoViewModel model)
        {
            try
            {
                
                model = _estadoAppService.Filtrar(f=>f.Id == id).SingleOrDefault();
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _estadoAppService.Remover(model);

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
