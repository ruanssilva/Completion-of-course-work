using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LVSA.Base.Application.Exceptions;
using LVSA.Base.Presentation.Rest;
using LVSA.Base.Presentation.ViewModels;
using LVSA.Noticia.Application.Interfaces;
using LVSA.Noticia.Application.ViewModels;
using LVSA.Noticia.Presentation.ViewModels;

namespace LVSA.Noticia.Presentation.Controllers
{
    public class NoticiaController : ControllerBase
    {
        private readonly INoticiaAppService _noticiaAppService;
        public NoticiaController(INoticiaAppService noticiaAppService)
        {
            _noticiaAppService = noticiaAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _noticiaAppService.SetSeguranca(Contexto.Seguranca);

            ViewBag.AplicacaoSet = Contexto.Seguranca.AplicacaoSet.Where(w => !w.Abstrata);
        }

        // GET: Noticia
        public ActionResult Index()
        {
            try
            {
                var tesste = _noticiaAppService.Filtrar(f => true).ToList();

                var model = _noticiaAppService.Filtrar(f => true).Select(s => new LVSA.Noticia.Presentation.ViewModels.NoticiaViewModel
                {
                    Titulo = s.Titulo,
                    Subtitulo = s.Subtitulo,
                    Autor = s.Autor,
                    ExpiraEm = s.ExpiraEm,
                    PublicadoEm = s.PublicadoEm,
                    Ativo = s.Ativo,
                    Id = s.Id
                }).ToList();

                return View("Index", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Noticia/Details/5
        public ActionResult Details(long id)
        {
            try
            {
                LVSA.Noticia.Presentation.ViewModels.NoticiaViewModel model = new LVSA.Noticia.Presentation.ViewModels.NoticiaViewModel(_noticiaAppService.ObterPorId(id));
                if (model == null)
                    throw new NoRecordsFoundException("Noticia não encontrada");

                return View("Details", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Noticia/Create
        public ActionResult Create()
        {
            try
            {
                return View("Create", new LVSA.Noticia.Presentation.ViewModels.NoticiaViewModel { PublicadoEm = DateTime.Now, ExpiraEm = DateTime.Now.AddDays(7) });
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Noticia/Create
        [HttpPost]
        public ActionResult Create(LVSA.Noticia.Presentation.ViewModels.NoticiaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Create", model);

                var imagens = new List<ImagemViewModel> { };

                if (model.FileSet != null)
                    foreach (var f in model.FileSet)
                    {
                        if (f != null)
                        {
                            MemoryStream target = new MemoryStream();
                            f.InputStream.CopyTo(target);

                            imagens.Add(new ImagemViewModel
                            {
                                Valor = target.ToArray(),
                                ContentType = f.ContentType,
                            });
                        }
                    }

                model.ImagemSet = model.ImagemSet != null ? model.ImagemSet.Intersect(imagens) : imagens;

                _noticiaAppService.Incluir(model);

                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Sucesso!",
                    Message = "Operação realizada com sucesso.",
                    Style = GritterStyle.Success,
                });

                new NoticiaRest(Token).Post();
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Noticia/Edit/5
        public ActionResult Edit(long id)
        {
            try
            {
                LVSA.Noticia.Presentation.ViewModels.NoticiaViewModel model = new LVSA.Noticia.Presentation.ViewModels.NoticiaViewModel(_noticiaAppService.ObterPorId(id));
                if (model == null)
                    throw new NoRecordsFoundException("Noticia não encontrada");

                return View("Edit", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Noticia/Edit/5
        [HttpPost]
        public ActionResult Edit(long id, LVSA.Noticia.Presentation.ViewModels.NoticiaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Edit", model);

                var imagens = model.ImagemSet != null ? model.ImagemSet.ToList() : new List<ImagemViewModel> { };

                if (model.FileSet != null)
                    foreach (var f in model.FileSet)
                    {
                        if (f != null)
                        {
                            MemoryStream target = new MemoryStream();
                            f.InputStream.CopyTo(target);

                            imagens.Add(new ImagemViewModel
                            {
                                Valor = target.ToArray(),
                                ContentType = f.ContentType,
                            });
                        }
                    }

                model.ImagemSet = imagens;

                _noticiaAppService.Atualizar(model);

                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Sucesso!",
                    Message = "Operação realizada com sucesso.",
                    Style = GritterStyle.Success,
                });

                new NoticiaRest(Token).Post();
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Noticia/Delete/5
        public ActionResult Delete(long id)
        {
            try
            {
                LVSA.Noticia.Presentation.ViewModels.NoticiaViewModel model = new LVSA.Noticia.Presentation.ViewModels.NoticiaViewModel(_noticiaAppService.ObterPorId(id));
                if (model == null)
                    throw new NoRecordsFoundException("Noticia não encontrada");

                return View("Delete", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: Noticia/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, LVSA.Noticia.Presentation.ViewModels.NoticiaViewModel model)
        {
            try
            {
                model = new LVSA.Noticia.Presentation.ViewModels.NoticiaViewModel(_noticiaAppService.ObterPorId(id));
                if (model == null)
                    throw new NoRecordsFoundException("Noticia não encontrada");

                _noticiaAppService.Remover(model);

                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Sucesso!",
                    Message = "Operação realizada com sucesso.",
                    Style = GritterStyle.Success,
                });

                new NoticiaRest(Token).Post();
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Nivel(long id)
        {
            try
            {
                LVSA.Noticia.Presentation.ViewModels.NoticiaViewModel model = new LVSA.Noticia.Presentation.ViewModels.NoticiaViewModel(_noticiaAppService.ObterPorId(id));
                if (model == null)
                    throw new NoRecordsFoundException("Noticia não encontrada");

                ViewBag.Noticia = model;
                ViewBag.Filiais = Contexto.Seguranca.FilialSet;

                return Index();
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Nivel(LVSA.Noticia.Presentation.ViewModels.NoticiaViewModel model)
        {
            try
            {
                model.FilialIdSet = model.FilialIdSet ?? new short[] { };

                _noticiaAppService.Contexto(model, Contexto.Seguranca.FilialSet.Where(w => model.FilialIdSet.Contains(w.Id)));

                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Sucesso!",
                    Message = "Operação realizada com sucesso.",
                    Style = GritterStyle.Success,
                });

                new NoticiaRest(Token).Post();

                return Index();
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Show()
        {
            try
            {
                IEnumerable<LVSA.Noticia.Application.ViewModels.NoticiaViewModel> model = new NoticiaRest(Token).Get();
                if (model == null)
                    throw new NoRecordsFoundException("Noticia não encontrada");

                return View("Show", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // GET: Noticia/Visualizar/5
        public ActionResult Visualizar(long id)
        {
            try
            {
                LVSA.Noticia.Application.ViewModels.NoticiaViewModel model = new NoticiaRest(Token).Get(id);
                if (model == null)
                    throw new NoRecordsFoundException("Noticia não encontrada");

                return View("Visualizar", model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }
    }
}
