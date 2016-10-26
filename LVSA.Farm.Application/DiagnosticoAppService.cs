using LVSA.Farm.Application.Interfaces;
using LVSA.Farm.Application.ViewModels;
using LVSA.Farm.Domain;
using LVSA.Farm.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Application
{
    public class DiagnosticoAppService : AppServiceBase<DiagnosticoViewModel, Diagnostico, IDiagnosticoService>, IDiagnosticoAppService
    {
        private readonly IRetratoAppService _retratoAppService;

        public override void SetSeguranca(Security.Application.Models.Seguranca seguranca, bool filter = true)
        {
            base.SetSeguranca(seguranca, filter);

            _retratoAppService.SetSeguranca(seguranca, filter);
        }

        public DiagnosticoAppService(IDiagnosticoService diagnosticoService, IRetratoAppService retratoAppService)
            : base(diagnosticoService)
        {
            _retratoAppService = retratoAppService;
        }

        public override IEnumerable<DiagnosticoViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public override IEnumerable<DiagnosticoViewModel> Filtrar(System.Linq.Expressions.Expression<Func<Diagnostico, bool>> predicate)
        {
            var model = base.Filtrar(predicate);

            var ids = model.Select(s => s.Id).ToList();

            var retratos = _retratoAppService.Filtrar(f => f.DiagnosticoId != null && ids.Contains((long)f.DiagnosticoId)).Select(s => s.Id).ToList();

            foreach (var x in model)
            {
                x.RetratoSet = x.RetratoSet.Where(w => retratos.Contains(w.Id));

                yield return x;
            }
        }

        public override DiagnosticoViewModel Incluir(DiagnosticoViewModel model)
        {
            var retratos = model.RetratoSet;

            model.RetratoSet = null;

            model = base.Incluir(model);

            var news = new List<RetratoViewModel>();


            if (retratos != null && retratos.Count() > 0)
                foreach (var r in retratos)
                {
                    news.Add(_retratoAppService.Incluir(new RetratoViewModel
                    {
                        DiagnosticoId = model.Id,
                        Valor = r.Valor
                    }));
                }

            model.RetratoSet = news;

            return model;
        }

        public override DiagnosticoViewModel Atualizar(DiagnosticoViewModel model)
        {
            var RetratoSet = model.RetratoSet.ToList() ?? new List<RetratoViewModel> { };
            model.RetratoSet = null;

            model = base.Atualizar(model);

            model.RetratoSet = RetratoSet;

            var inteiros = model.RetratoSet.Select(s => s.Id).ToList();

            var retirar = _retratoAppService.Filtrar(f => f.DiagnosticoId == model.Id && !inteiros.Contains(f.Id)).ToList();
            foreach (var r in retirar)
                _retratoAppService.Remover(r);

            foreach (var i in model.RetratoSet.Where(w => !(w.Id > 0) && w.Valor != null))
                _retratoAppService.Incluir(new RetratoViewModel
                {
                    Valor = i.Valor,
                    DiagnosticoId = model.Id
                });

            return model;
        }
    }
}
