

using LVSA.Base.Presentation.ViewModels;
using LVSA.Report.Application.Interfaces;
using LVSA.Report.Application.ViewModels;
using LVSA.Report.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Report.Presentation.Controllers
{
    public class GrupoController : ControllerBase
    {
        private readonly IGrupoAppService _grupoAppService;
        private readonly ICuboAppService _cuboAppService;
        private readonly ICategoriaCuboAppService _categoriaCuboAppService;

        public GrupoController(IGrupoAppService grupoAppService, ICategoriaCuboAppService categoriaCuboAppService, ICuboAppService cuboAppService)
        {
            _grupoAppService = grupoAppService;
            _categoriaCuboAppService = categoriaCuboAppService;
            _cuboAppService = cuboAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _grupoAppService.SetSeguranca(Contexto.Seguranca);
            _categoriaCuboAppService.SetSeguranca(Contexto.Seguranca);
            _cuboAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Grupo
        public ActionResult Index()
        {
            try
            {
                IEnumerable<GrupoViewModel> model = _grupoAppService.Todos();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Grupo/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                GrupoViewModel model = _grupoAppService.ObterPorId(id);
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

        // GET: Grupo/Create
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

        // POST: Grupo/Create
        [HttpPost]
        public ActionResult Create(GrupoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                // TODO: Add insert logic here
                _grupoAppService.Incluir(model);

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

        // GET: Grupo/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                GrupoViewModel model = _grupoAppService.ObterPorId(id);
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

        // POST: Grupo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GrupoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                // TODO: Add update logic here
                _grupoAppService.Atualizar(model);

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

        // GET: Grupo/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                GrupoViewModel model = _grupoAppService.ObterPorId(id);
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

        // POST: Grupo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, GrupoViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model = _grupoAppService.ObterPorId(id);
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                _grupoAppService.Remover(model);

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

        //
        // GET: /Grupo/Cubo/5
        public ActionResult Cubo(int id)
        {
            try
            {
                GrupoAppViewModel model = new GrupoAppViewModel(_grupoAppService.ObterPorId(id));
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                model.Cubos = null;

                ViewBag.CategoriaSet = _categoriaCuboAppService.Filtrar(f => f.Ativo);

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        //
        // POST: /Grupo/Cubo/5
        [HttpPost]
        public ActionResult Cubo(int id, GrupoAppViewModel model)
        {
            try
            {
                int categoriaid = model.CategoriaId.GetValueOrDefault();

                if (model.Cubos == null)
                {
                    model = new GrupoAppViewModel(_grupoAppService.ObterPorId(id));
                    if (model == null)
                        throw new ArgumentNullException("model");

                    IEnumerable<CuboViewModel> cubos = _cuboAppService.Filtrar(f => f.Ativo && (categoriaid > 0 ? f.CategoriaCuboId == categoriaid : true));

                    model.Cubos = (from x in cubos

                                   join y in model.Cubos
                                       on new { x.Id }
                                     equals new { y.Id } into _join
                                   from y in _join.DefaultIfEmpty()

                                   select new CuboViewModel
                                   {
                                       Id = x.Id,
                                       Codigo = x.Codigo,
                                       Descricao = x.Descricao,
                                       Icon = x.Icon,
                                       CategoriaCuboId = x.CategoriaCuboId,
                                       Acesso = y != null
                                   }).ToList();

                    ViewBag.CategoriaSet = _categoriaCuboAppService.Filtrar(f => f.Ativo);

                    return View(model);
                }
                else
                {
                    List<CuboViewModel> cubos = model.Cubos;

                    model = new GrupoAppViewModel(_grupoAppService.ObterPorId(id));
                    if (model == null)
                        throw new Exception("Registro não encontrado.");

                    model.Cubos = cubos;
                    model.CategoriaId = categoriaid;

                    _grupoAppService.Atualizar(model);

                    ViewBag.CategoriaSet = _categoriaCuboAppService.Filtrar(f => f.Ativo);

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }
    }
}
