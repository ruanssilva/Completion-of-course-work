using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.Models;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Domain;
using LVSA.Security.Domain.Interfaces.Services;

namespace LVSA.Security.Application
{
    public class ContextoAppService : IContextoAppService
    {
        private readonly IColigadaService _coligadaService;
        private readonly IFilialService _gFilialService;
        private readonly IAplicacaoAcessoService _aplicacaoAcessoService;
        private readonly IAplicacaoAppService _aplicacaoAppService;

        public ContextoAppService(IColigadaService coligadaService, IFilialService gFilialService, IAplicacaoAcessoService aplicacaoAcessoService, IAplicacaoAppService aplicacaoAppService)
        {
            _coligadaService = coligadaService;
            _gFilialService = gFilialService;
            _aplicacaoAcessoService = aplicacaoAcessoService;
            _aplicacaoAppService = aplicacaoAppService;
        }

        protected Seguranca Seguranca { get; set; }
        public virtual void SetSeguranca(Seguranca seguranca)
        {
            Seguranca = seguranca;
        }

        public IEnumerable<ColigadaViewModel> ObterTodasColigada()
        {
            return _coligadaService.Find(f => true).Select(s => new ColigadaViewModel
            {
                Id = s.Id,
                Nome = s.Nome
            });
        }

        public IEnumerable<FilialViewModel> ObterTodasFilial()
        {
            return _gFilialService.Find(f => true).Select(s => new FilialViewModel
            {
                Id = s.Id,
                Nome = s.Nome
            });
        }

        public IEnumerable<AplicacaoViewModel> Acessos(Expression<Func<AplicacaoAcesso, bool>> predicate)
        {
            var aplicacoes = _aplicacaoAcessoService.Find(predicate).ToList().Select(s => s.Aplicacao);

            foreach (var a in aplicacoes)
            {
                var aplicacaoIdSet = a.AplicacaoDependenteSet.Select(s => s.AplicacaoId) ?? new int[] { };
                IEnumerable<AplicacaoViewModel> apps = _aplicacaoAppService.Filtrar(f => f.Abstrata && aplicacaoIdSet.Contains(f.Id)).ToList();

                foreach (var app in apps)
                    yield return app;

                yield return Mapper.Map<Aplicacao, AplicacaoViewModel>(a);
            }

            //return Mapper.Map<IEnumerable<Aplicacao>, IEnumerable<AplicacaoViewModel>>(aplicacoes);
        }

        public void Conceder(FilialViewModel model)
        {
            int[] AplicacaoIdSet = model.AplicacaoSet.Select(s => s.Id).ToArray();

            var acessos = _aplicacaoAcessoService.Find(f =>
                f.FilialId == model.Id &&
                f.ColigadaId == model.ColigadaId
            ).ToList();

            foreach (var d in acessos.Where(w => model.AplicacaoSet.Where(w1 => !w1.Selecionado).Select(s => s.Id).Contains(w.AplicacaoId)))
                _aplicacaoAcessoService.Delete(d);

            foreach (var i in model.AplicacaoSet.Where(w => w.Selecionado && !acessos.Select(s => s.AplicacaoId).Contains(w.Id)))
            {
                _aplicacaoAcessoService.Add(new AplicacaoAcesso
                {
                    AplicacaoId = i.Id,
                    ColigadaId = model.ColigadaId,
                    FilialId = model.Id,
                    Vencimento = i.Vencimento,
                    Ativo = true,

                    RECCREATEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null
                });
            }

        }
    }
}
