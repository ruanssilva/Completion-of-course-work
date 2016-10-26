using LVSA.Base.Application.Exceptions;
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
    public class DoencaAppService : AppServiceBase<DoencaViewModel, Doenca, IDoencaService>, IDoencaAppService
    {
        private readonly IRetratoAppService _retratoAppService;

        public DoencaAppService(IDoencaService doencaService, IRetratoAppService retratoAppService)
            : base(doencaService)
        {
            _retratoAppService = retratoAppService;
        }

        public override void SetSeguranca(Security.Application.Models.Seguranca seguranca, bool filter = true)
        {
            base.SetSeguranca(seguranca, filter);

            _retratoAppService.SetSeguranca(seguranca, filter);
        }

        public override IEnumerable<DoencaViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public override IEnumerable<DoencaViewModel> Filtrar(System.Linq.Expressions.Expression<Func<Doenca, bool>> predicate)
        {
            var model = base.Filtrar(predicate);

            var retratos = _retratoAppService.Filtrar(f => f.DoencaId != null).Select(s => s.Id).ToList();

            foreach (var x in model)
            {
                x.RetratoSet = x.RetratoSet.Where(w => retratos.Contains(w.Id));

                yield return x;
            }
        }

        public override DoencaViewModel Incluir(DoencaViewModel model)
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
                        DoencaId = model.Id,
                        Valor = r.Valor
                    }));
                }

            model.RetratoSet = news;

            return model;
        }

        public override DoencaViewModel Atualizar(DoencaViewModel model)
        {
            var RetratoSet = model.RetratoSet.ToList() ?? new List<RetratoViewModel> { };
            model.RetratoSet = null;

            model = base.Atualizar(model);

            model.RetratoSet = RetratoSet;

            var inteiros = model.RetratoSet.Select(s => s.Id).ToList();

            var retirar = _retratoAppService.Filtrar(f => f.DoencaId == model.Id && !inteiros.Contains(f.Id)).ToList();
            foreach (var r in retirar)
                _retratoAppService.Remover(r);

            foreach (var i in model.RetratoSet.Where(w => !(w.Id > 0) && w.Valor != null))
                _retratoAppService.Incluir(new RetratoViewModel
                {
                    Valor = i.Valor,
                    DoencaId = model.Id
                });

            return model;
        }

        public override void Remover(DoencaViewModel model)
        {
            var entity = Service.Find(f => f.Id == model.Id && f.RECDELETEDON == null).SingleOrDefault();
            if (entity == null)
                throw new NoRecordsFoundException("Registro não encontrado");

            entity.RECDELETEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null;

            Service.Delete(entity);
        }
    }
}
