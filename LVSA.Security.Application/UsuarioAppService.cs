using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Application.Exceptions;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Domain;
using LVSA.Security.Domain.Interfaces.Services;

namespace LVSA.Security.Application
{
    public class UsuarioAppService : AppServiceBase<UsuarioViewModel, Usuario, IUsuarioService>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioFilialService _usuarioFilialService;
        private readonly IAgrupamentoService _agrupamentoService;
        private readonly IGrupoService _grupoService;

        public UsuarioAppService(IUsuarioService usuarioService, IGrupoService grupoService, IUsuarioFilialService sUsuarioFilialService, IAgrupamentoService agrupamentoService)
            : base(usuarioService)
        {
            _usuarioService = usuarioService;
            _usuarioFilialService = sUsuarioFilialService;
            _agrupamentoService = agrupamentoService;
            _grupoService = grupoService;
        }

        public override IEnumerable<UsuarioViewModel> Todos()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<UsuarioViewModel> Filtrar(Expression<Func<Usuario, bool>> predicate)
        {
            var model = base.Filtrar(predicate);

            foreach (var x in model)
            {
                x.GrupoSet = Mapper.Map<IEnumerable<Grupo>, IEnumerable<GrupoViewModel>>(_agrupamentoService.Find(f => f.UsuarioId == x.Id).ToList().Select(s => s.Grupo)).ToList();
                x.UsuarioFilialSet = _usuarioFilialService.Find(f => f.UsuarioId == x.Id).ToList().Select(s => new UsuarioFilialViewModel
                {
                    ColigadaId = s.ColigadaId,
                    FilialId = s.FilialId,
                    UsuarioId = s.UsuarioId
                });

                var coligadas = x.UsuarioFilialSet.Select(s => (short?)s.ColigadaId).ToList();
                var filiais = x.UsuarioFilialSet.Select(s => (short?)s.FilialId).ToList();

                List<Grupo> grupos = _grupoService.Find(f => (bool)f.Publico && coligadas.Contains(f.ColigadaId) && filiais.Contains(f.FilialId)).ToList();
                x.GrupoSet = x.GrupoSet.Concat(Mapper.Map<IEnumerable<Grupo>,IEnumerable<GrupoViewModel>>(grupos));

            }




            return model;
        }

        public virtual IEnumerable<UsuarioViewModel> Buscar(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioViewModel> ObterPorNome(string nome)
        {
            return Filtrar(f => f.Nome.Contains(nome));
        }


        public UsuarioViewModel ObterPorCodigo(string codigo)
        {
            return Filtrar(f => f.Codigo != null && f.Codigo == codigo).FirstOrDefault();
        }

        public UsuarioViewModel ObterPorId(long id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }

        public override UsuarioViewModel Atualizar(UsuarioViewModel model)
        {
            var entity = _usuarioService.Find(f => f.Id == model.Id).SingleOrDefault();
            if (entity == null)
                throw new NoRecordsFoundException("Registro não encontrado");

            entity.Codigo = model.Codigo;
            entity.Nome = model.Nome;
            entity.Bloqueado = model.Bloqueado;
            entity.TipoUsuarioId = model.TipoUsuarioId;
            entity.Email = model.Email;
            entity.RECMODIFIEDBY = Seguranca != null ? Seguranca.CODUSUARIO : entity.RECMODIFIEDBY;

            Service.Update(entity);

            return Mapper.Map<Usuario, UsuarioViewModel>(entity);
        }


        public UsuarioViewModel ObterPorCodigo(string codigo, bool filiais = false)
        {
            return ObterPorCodigo(codigo);
        }


        public UsuarioViewModel ObterPorId(long id, bool filiais = false)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }

        public override UsuarioViewModel Incluir(UsuarioViewModel model)
        {
            //if (Filtrar(f => f.Nome == model.Nome).Count() > 0)
            //    throw new Exception("O usuário já existe.");

            return base.Incluir(model);
        }


        public void Agrupar(UsuarioViewModel model)
        {
            long[] GrupoIdSet = model.GrupoSet.Select(s => s.Id).ToArray();

            var agrupamentos = _agrupamentoService.Find(f => f.UsuarioId == model.Id && GrupoIdSet.Contains(f.GrupoId)).ToList();
            foreach (var d in agrupamentos.Where(w => model.GrupoSet.Where(w1 => !w1.Selecionado).Select(s => s.Id).Contains(w.GrupoId)))
                _agrupamentoService.Delete(d);

            foreach (var i in model.GrupoSet.Where(w => w.Selecionado && !agrupamentos.Select(s => s.GrupoId).Contains(w.Id)))
            {
                _agrupamentoService.Add(new Agrupamento
                {
                    GrupoId = i.Id,
                    UsuarioId = model.Id,

                    RECCREATEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null
                });
            }
        }


        public void AtualizarCodigo(string codigo)
        {
            if (Service.Find(f => f.Codigo == codigo).Count() > 0)
                throw new Exception("Já existe o código selecionado");

            var entity = Service.Find(f => f.Id == Seguranca.Usuario.Id).Single();

            entity.Codigo = codigo;

            Service.Update(entity);
        }


        public void AtualizarAvatar(byte[] imagem)
        {
            var entity = Service.Find(f => f.Id == Seguranca.Usuario.Id).Single();

            entity.Avatar = imagem;

            Service.Update(entity);
        }
    }
}
