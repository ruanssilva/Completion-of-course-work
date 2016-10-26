using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LVSA.Security.Application.Interfaces;
using LVSA.Security.Application.ViewModels;
using LVSA.Security.Domain;
using LVSA.Security.Domain.Interfaces.Services;

namespace LVSA.Security.Application
{
    public class AplicacaoAppService : AppServiceBase<AplicacaoViewModel, Aplicacao, IAplicacaoService>, IAplicacaoAppService
    {
        private readonly IAplicacaoDependenciaService _aplicacaoDependenciaService;
        private readonly IParametrizacaoService _parametrizacaoService;
        private readonly IRecursoAppService _recursoAppService;

        public AplicacaoAppService(IAplicacaoService aplicacaoService, IAplicacaoDependenciaService aplicacaoDependenciaService, IParametrizacaoService parametrizacaoService, IRecursoAppService recursoAppService)
            : base(aplicacaoService)
        {
            _aplicacaoDependenciaService = aplicacaoDependenciaService;
            _parametrizacaoService = parametrizacaoService;
            _recursoAppService = recursoAppService;
        }

        public override IEnumerable<AplicacaoViewModel> Filtrar(System.Linq.Expressions.Expression<Func<Aplicacao, bool>> predicate)
        {
            var model = Service.Find(predicate).ToList();

            int[] appsid = model.Select(s => s.Id).ToArray();

            var recursos = _recursoAppService.Filtrar(f => appsid.Contains(f.AplicacaoId));

            foreach (var m in model.OrderBy(o => o.Nome))
            {
                m.GrupoSet = m.GrupoSet.Where(w => w.RECDELETEDON == null).ToList();

                var aplicacaoIdSet = m.AplicacaoDependenteSet.Select(s => s.AplicacaoId);

                IEnumerable<AplicacaoViewModel> apps = Filtrar(f => f.Abstrata && aplicacaoIdSet.Contains(f.Id)).ToList();
                IEnumerable<ParametroViewModel> parametros = m.ParametrizacaoSet.Select(s => new ParametroViewModel
                {
                    Id = s.ParametroId,
                    Nome = s.Parametro.Nome,
                    Descricao = s.Parametro.Descricao,
                    Type = s.Parametro.Type,
                    TSQL = s.Parametro.TSQL,
                    TSQLAtivo = s.Parametro.TSQLAtivo,
                    Mascara = s.Parametro.Mascara,
                    Regex = s.Parametro.Regex,
                    Ativo = s.Parametro.Ativo,
                    Codigo = s.Codigo,
                    Exibicao = s.Exibicao,
                    Obrigatorio = s.Obrigatorio,
                    Multi = s.Multi,
                    Sequencia = s.Sequencia
                });

                var x = Mapper.Map<Aplicacao, AplicacaoViewModel>(m);

                x.RecursoSet = recursos.Where(w => w.AplicacaoId == m.Id);

                x.AplicacaoSet = apps;
                x.ParametroSet = parametros;

                x.AplicacaoIdSet = apps.Select(s => s.Id).ToArray();

                yield return x;
            }
        }

        public AplicacaoViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }

        public override IEnumerable<AplicacaoViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public override AplicacaoViewModel Incluir(AplicacaoViewModel model)
        {
            var idaplicacaoset = model.AplicacaoIdSet ?? new int[] { };

            model = base.Incluir(model);

            foreach (var a in idaplicacaoset)
                _aplicacaoDependenciaService.Add(new AplicacaoDependencia
                {
                    AplicacaoId = a,
                    AplicacaoDependenteId = model.Id,

                    RECCREATEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null
                });

            return model;
        }

        public override AplicacaoViewModel Atualizar(AplicacaoViewModel model)
        {
            model.AplicacaoIdSet = model.AplicacaoIdSet ?? new int[] { };

            var idaplicacaoset = _aplicacaoDependenciaService.Find(f => f.AplicacaoDependenteId == model.Id).Select(s => s.AplicacaoId).ToList();
            foreach (var d in idaplicacaoset.Where(w => !model.AplicacaoIdSet.Contains(w)))
            {
                var entity = _aplicacaoDependenciaService.Find(f => f.AplicacaoId == d && f.AplicacaoDependenteId == model.Id).SingleOrDefault();
                if (entity != null)
                    _aplicacaoDependenciaService.Delete(entity);
            }

            foreach (var i in model.AplicacaoIdSet.Where(w => !idaplicacaoset.Contains(w)))
                _aplicacaoDependenciaService.Add(new AplicacaoDependencia
                {
                    AplicacaoId = i,
                    AplicacaoDependenteId = model.Id,

                    RECCREATEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null
                });


            return base.Atualizar(model);
        }

        public void Parametrizar(AplicacaoViewModel aplicacao, ParametroViewModel parametro)
        {
            _parametrizacaoService.Add(new Parametrizacao
            {
                Codigo = parametro.Codigo,
                AplicacaoId = aplicacao.Id,
                ParametroId = parametro.Id,
                Exibicao = parametro.Exibicao,
                Obrigatorio = parametro.Obrigatorio,
                Multi = parametro.Multi,
                Sequencia = parametro.Sequencia,

                RECCREATEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null
            });
        }

        public void Desparametrizar(AplicacaoViewModel aplicacao, ParametroViewModel parametro)
        {
            var parametrizacao = _parametrizacaoService.Find(f =>
                f.AplicacaoId == aplicacao.Id &&
                f.ParametroId == parametro.Id &&
                f.Exibicao == parametro.Exibicao &&
                f.Sequencia == parametro.Sequencia &&
                parametro.Codigo == parametro.Codigo
            ).FirstOrDefault();

            if (parametrizacao != null)
                _parametrizacaoService.Delete(parametrizacao);
        }
    }
}
