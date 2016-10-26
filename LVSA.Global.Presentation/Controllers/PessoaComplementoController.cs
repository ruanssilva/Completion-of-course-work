
using LVSA.Base.Presentation.ViewModels;
using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using LVSA.Global.Presentation.ViewModels;
using LVSA.Security.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Global.Presentation.Controllers
{
    public class PessoaComplementoController : ControllerBase
    {
        private readonly IPessoaFisicaComplementoAppService _pessoaFisicaComplementoAppService;
        private readonly IPessoaFisicaAppService _pessoaFisicaAppService;
        private readonly ICidadeAppService _cidadeAppService;
        private readonly IImagemAppService _imagemAppService;
        private readonly IRacaCorAppService _racaCorAppService;
        private readonly IEscolaridadeAppService _escolaridadeAppService;
        private readonly ITitulacaoAppService _titulacaoAppService;
        private readonly IUsuarioAppService _usuarioAppService;

        public PessoaComplementoController(IPessoaFisicaComplementoAppService pessoaFisicaComplementoAppService, IUsuarioAppService usuarioAppService, ITitulacaoAppService titulacaoAppService, IEscolaridadeAppService escolaridadeAppService, IRacaCorAppService racaCorAppService, IPessoaFisicaAppService pessoaFisicaAppService, ICidadeAppService cidadeAppService, IImagemAppService imagemAppService)
        {
            _pessoaFisicaComplementoAppService = pessoaFisicaComplementoAppService;
            _cidadeAppService = cidadeAppService;
            _pessoaFisicaAppService = pessoaFisicaAppService;
            _imagemAppService = imagemAppService;
            _racaCorAppService = racaCorAppService;
            _escolaridadeAppService = escolaridadeAppService;
            _titulacaoAppService = titulacaoAppService;
            _usuarioAppService = usuarioAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _pessoaFisicaComplementoAppService.SetSeguranca(Contexto.Seguranca);
            _pessoaFisicaAppService.SetSeguranca(Contexto.Seguranca);
            _cidadeAppService.SetSeguranca(Contexto.Seguranca);
            _imagemAppService.SetSeguranca(Contexto.Seguranca);
            _racaCorAppService.SetSeguranca(Contexto.Seguranca);
            _escolaridadeAppService.SetSeguranca(Contexto.Seguranca);
            _titulacaoAppService.SetSeguranca(Contexto.Seguranca);

            ViewBag.CidadeSet = _cidadeAppService.Todos();
            ViewBag.EscolaridadeSet = _escolaridadeAppService.Todos();
            ViewBag.TitulacaoSet = _titulacaoAppService.Todos();
            ViewBag.RacaCorSet = _racaCorAppService.Todos();
        }

        // GET: PessoaComplemento/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                PessoaFisicaComplementoViewModel model = _pessoaFisicaComplementoAppService.Filtrar(f => f.PessoaId == id).SingleOrDefault();
                if (model == null)
                {
                    PessoaFisicaViewModel pessoa = _pessoaFisicaAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                    if (pessoa == null)
                        throw new Exception("Registro não encontrado.");

                    model = new PessoaFisicaComplementoViewModel
                    {
                        PessoaId = pessoa.Id,
                        Pessoa = pessoa
                    };
                }

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }



        // GET: PessoaComplemento/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                PessoaFisicaComplementoAppViewModel model = new PessoaFisicaComplementoAppViewModel(_pessoaFisicaComplementoAppService.Filtrar(f => f.PessoaId == id).SingleOrDefault());
                if (model == null)
                {
                    PessoaFisicaViewModel pessoa = _pessoaFisicaAppService.Filtrar(f => f.Id == id).SingleOrDefault();
                    if (pessoa == null)
                        throw new Exception("Registro não encontrado.");

                    model = new PessoaFisicaComplementoAppViewModel();
                }

                List<long> UsuarioIds = _pessoaFisicaComplementoAppService.Filtrar(f => f.UsuarioId != null).Select(s => (long)s.UsuarioId).ToList();
                ViewBag.UsuarioSet = _usuarioAppService.Filtrar(f => !UsuarioIds.Contains(f.Id) || f.Id == model.UsuarioId);


                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        // POST: PessoaComplemento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PessoaFisicaComplementoAppViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<long> UsuarioIds = _pessoaFisicaComplementoAppService.Filtrar(f => f.UsuarioId != null).Select(s => (long)s.UsuarioId).ToList();
                    ViewBag.UsuarioSet = _usuarioAppService.Filtrar(f => !UsuarioIds.Contains(f.Id) || f.Id == model.UsuarioId);

                    return View(model);
                }
                // TODO: Add update logic here

                if (model.File != null)
                {
                    MemoryStream target = new MemoryStream();
                    model.File.InputStream.CopyTo(target);

                    ImagemViewModel imagem = new ImagemViewModel
                    {
                        Nome = Guid.NewGuid() + "." + Path.GetExtension(model.File.FileName),
                        ContentType = model.File.ContentType,
                        Valor = target.ToArray()
                    };

                    imagem = _imagemAppService.Incluir(imagem);

                    model.ImagemId = imagem.Id;
                }



                if (model.PessoaId > 0)
                    _pessoaFisicaComplementoAppService.Atualizar(model);
                else
                {
                    model.PessoaId = id;
                    model = new PessoaFisicaComplementoAppViewModel(_pessoaFisicaComplementoAppService.Incluir(model));
                }

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

            return RedirectToAction("Details", new { id = model.PessoaId });
        }

    }
}
