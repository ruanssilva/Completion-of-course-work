

using LVSA.Base.Presentation.ViewModels;
using LVSA.Report.Application.Interfaces;
using LVSA.Report.Application.ViewModels;
using LVSA.Report.Presentation.ViewModels;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Report.Presentation.Controllers
{
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IUsuarioGrupoAppService _usuarioGrupoAppService;
        private readonly LVSA.Report.Application.Interfaces.IGrupoAppService _grupoAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService, LVSA.Report.Application.Interfaces.IGrupoAppService grupoAppService, IUsuarioGrupoAppService usuarioGrupoAppService)
        {
            _usuarioAppService = usuarioAppService;
            _grupoAppService = grupoAppService;
            _usuarioGrupoAppService = usuarioGrupoAppService;
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _usuarioAppService.SetSeguranca(Contexto.Seguranca);
            _grupoAppService.SetSeguranca(Contexto.Seguranca);
            _usuarioGrupoAppService.SetSeguranca(Contexto.Seguranca);
        }

        // GET: Usuario
        public ActionResult Index()
        {
            try
            {
                IEnumerable<UsuarioViewModel> model = _usuarioAppService.Todos();

                //List<int> ids = model.Select(s => s.Id).ToList();

                //model = (from m in model

                //         join u in UserManager.Users.Where(w => ids.Contains((int)w.UsuarioId))
                //             on new { m.Id }
                //         equals new { Id = (u.UsuarioId ?? 0) }

                //         select new UsuarioViewModel
                //         {
                //             Id = m.Id,
                //             Bloqueado = u.LockoutEnabled,
                //             Email = u.Email,
                //             Nome = m.Nome
                //         }).ToList();


                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Usuario/Grupo/5
        public ActionResult Grupo(int id)
        {
            try
            {
                UsuarioAppViewModel model = new UsuarioAppViewModel(_usuarioAppService.ObterPorId(id));
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                model.Grupos = _usuarioGrupoAppService.Filtrar(f => f.UsuarioId == model.Id).Select(s => s.Grupo);

                IEnumerable<LVSA.Report.Application.ViewModels.GrupoViewModel> grupos = _grupoAppService.Filtrar(f => f.Ativo);

                var _grupos = (from x in grupos

                               join y in model.Grupos
                                   on new { x.Id }
                               equals new { y.Id } into _join
                               from y in _join.DefaultIfEmpty()

                               select new LVSA.Report.Application.ViewModels.GrupoViewModel
                               {
                                   Id = x.Id,
                                   Nome = x.Nome,
                                   Selecionado = y != null,
                                   Descricao = x.Descricao
                               });

                model.Grupos = _grupos.ToList();

                return View(model);
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

        //
        // POST: /Usuario/Grupo/5
        [HttpPost]
        public ActionResult Grupo(UsuarioAppViewModel model)
        {
            try
            {
                IEnumerable<LVSA.Report.Application.ViewModels.GrupoViewModel> grupos = model.Grupos;

                model = new UsuarioAppViewModel(_usuarioAppService.ObterPorId(model.Id));
                if (model == null)
                    throw new Exception("Registro não encontrado.");

                var update = _usuarioGrupoAppService.Filtrar(f => f.UsuarioId == model.Id).Select(s => s.Grupo);

                foreach (var grupo in update)
                    _usuarioGrupoAppService.Remover(new UsuarioGrupoViewModel { GrupoId = grupo.Id, UsuarioId = model.Id });

                foreach (var grupo in grupos.Where(w => w.Selecionado))
                    _usuarioGrupoAppService.Incluir(new UsuarioGrupoViewModel { GrupoId = grupo.Id, UsuarioId = model.Id });

                return RedirectToAction("Grupo", new { id = model.Id });
            }
            catch (Exception ex)
            {
                HandlingException(ex);
            }

            return RedirectToAction("Index");
        }

    }
}
