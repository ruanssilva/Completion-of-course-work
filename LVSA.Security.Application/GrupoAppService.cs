using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Application.Exceptions;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Domain;
using LVSA.Security.Domain.Interfaces.Services;

namespace LVSA.Security.Application
{
    public class GrupoAppService : AppServiceBase<GrupoViewModel, Grupo, IGrupoService>, IGrupoAppService
    {
        private readonly IAgrupamentoService _agrupamentoService;
        private readonly IPermissaoService _permissaoService;
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IUsuarioFilialService _sUsuarioFilialService;

        public GrupoAppService(IGrupoService grupoService, IUsuarioFilialService sUsuarioFilialService, IAgrupamentoService agrupamentoService, IUsuarioAppService usuarioAppService, IPermissaoService permissaoService)
            : base(grupoService)
        {
            _agrupamentoService = agrupamentoService;
            _usuarioAppService = usuarioAppService;
            _permissaoService = permissaoService;
            _sUsuarioFilialService = sUsuarioFilialService;
        }

        public override IEnumerable<GrupoViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public override void Remover(GrupoViewModel model)
        {
            var entity = Service.Find(f => f.Id == model.Id && f.RECDELETEDON == null).SingleOrDefault();
            if (entity == null)
                throw new NoRecordsFoundException("Grupo não encontrado");

            entity.RECDELETEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null;

            Service.Delete(entity);
        }

        public override IEnumerable<GrupoViewModel> Filtrar(System.Linq.Expressions.Expression<Func<Grupo, bool>> predicate)
        {
            var model = base.Filtrar(predicate).ToList();

            foreach (var x in model)
            {
                var usuarioids = _agrupamentoService.Find(f => f.GrupoId == x.Id).Select(s => s.UsuarioId).ToList();
                x.UsuarioSet = _usuarioAppService.Filtrar(f => usuarioids.Contains(f.Id)).ToList();
                x.PermissaoSet = Mapper.Map<IEnumerable<Permissao>, IEnumerable<PermissaoViewModel>>(_permissaoService.Find(f => f.GrupoId == x.Id && f.RECDELETEDON == null).ToList());
            }

            return model;
        }


        public IEnumerable<GrupoViewModel> Filtrar(System.Linq.Expressions.Expression<Func<Grupo, bool>> predicate, bool usuario)
        {
            if (usuario)
                return Filtrar(predicate);

            return base.Filtrar(predicate).ToList();
        }

        public virtual GrupoViewModel ObterPorId(long id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }

        public void Agrupar(GrupoViewModel model)
        {
            long[] UsuarioIdSet = model.UsuarioSet.Select(s => s.Id).ToArray();

            var agrupamentos = _agrupamentoService.Find(f => f.GrupoId == model.Id && UsuarioIdSet.Contains(f.UsuarioId)).ToList();
            foreach (var d in agrupamentos.Where(w => model.UsuarioSet.Where(w1 => !w1.Selecionado).Select(s => s.Id).Contains(w.UsuarioId)))
                _agrupamentoService.Delete(d);

            foreach (var i in model.UsuarioSet.Where(w => w.Selecionado && !agrupamentos.Select(s => s.UsuarioId).Contains(w.Id)))
            {
                _agrupamentoService.Add(new Agrupamento
                {
                    GrupoId = model.Id,
                    UsuarioId = i.Id,

                    RECCREATEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null

                });
            }
        }


        public void Esvaziar(GrupoViewModel model)
        {
            var agrupamentos = _agrupamentoService.Find(f => f.GrupoId == model.Id).ToList();
            foreach (var d in agrupamentos)
                _agrupamentoService.Delete(d);
        }


        public void Retirar(GrupoViewModel grupo, UsuarioViewModel usuario)
        {
            var agrupamentos = _agrupamentoService.Find(f => f.GrupoId == grupo.Id && f.UsuarioId == usuario.Id).ToList();
            foreach (var d in agrupamentos)
                _agrupamentoService.Delete(d);
        }


        public void Permitir(GrupoViewModel model)
        {
            long[] RecursoIdSet = model.PermissaoSet.Select(s => (long)s.RecursoId).ToArray();

            var permissoes = _permissaoService.Find(f => f.GrupoId == model.Id && RecursoIdSet.Contains((long)f.RecursoId) && f.RECDELETEDON == null).ToList();
            foreach (var d in permissoes.Where(w => model.PermissaoSet.Where(w1 => !w1.Selecionado).Select(s => s.RecursoId).Contains(w.RecursoId)))
            {
                d.RECDELETEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null;

                _permissaoService.Delete(d);
            }

            foreach (var i in model.PermissaoSet.Where(w => w.Selecionado && !permissoes.Select(s => s.RecursoId).Contains(w.RecursoId)))
            {
                _permissaoService.Add(new Permissao
                {
                    GrupoId = model.Id,
                    RecursoId = i.RecursoId,
                    Read = i.Read,
                    Write = i.Write,
                    Rewrite = i.Rewrite,
                    Delete = i.Delete,

                    RECCREATEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null

                });
            }

            foreach (var u in permissoes.Where(w => model.PermissaoSet.Where(w1 => w1.Selecionado && (w.Read != w1.Read || w.Write != w1.Write || w.Rewrite != w1.Rewrite || w.Delete != w1.Delete)).Select(s => s.RecursoId).Contains(w.RecursoId)))
            {
                var m = model.PermissaoSet.Where(w => w.RecursoId == u.RecursoId).Single();

                u.Read = m.Read;
                u.Write = m.Write;
                u.Rewrite = m.Rewrite;
                u.Delete = m.Delete;

                u.RECMODIFIEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null;

                _permissaoService.Update(u);
            }

        }


    }
}
