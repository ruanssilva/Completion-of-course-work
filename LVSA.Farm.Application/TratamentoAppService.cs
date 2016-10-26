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
using LVSA.Security.Application.Models;

namespace LVSA.Farm.Application
{
    public class TratamentoAppService : AppServiceBase<TratamentoViewModel, Tratamento, ITratamentoService>, ITratamentoAppService
    {
        private readonly IDosagemAppService _dosagemAppService;
        private readonly IDosagemService _dosagemService;
        public TratamentoAppService(ITratamentoService tratamentoService, IDosagemAppService dosagemAppService, IDosagemService dosagemService)
            : base(tratamentoService)
        {
            _dosagemAppService = dosagemAppService;
            _dosagemService = dosagemService;
        }

        public override void SetSeguranca(Seguranca seguranca, bool filter = true)
        {
            base.SetSeguranca(seguranca, filter);

            _dosagemAppService.SetSeguranca(seguranca, filter);
        }

        public override IEnumerable<TratamentoViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public override IEnumerable<TratamentoViewModel> Filtrar(System.Linq.Expressions.Expression<Func<Tratamento, bool>> predicate)
        {
            var model = base.Filtrar(predicate);

            var dosagens = _dosagemAppService.Filtrar(f => f.TratamentoId != null).Select(s => s.Id).ToList();

            foreach (var x in model)
            {
                x.DosagemSet = x.DosagemSet.Where(w => dosagens.Contains(w.Id));

                yield return x;
            }
        }

        public override TratamentoViewModel Incluir(TratamentoViewModel model)
        {
            var dosagens = model.DosagemSet;

            model.DosagemSet = null;

            model = base.Incluir(model);

            var news = new List<DosagemViewModel>();



            if (dosagens != null && dosagens.Count() > 0)
                foreach (var r in dosagens)
                {
                    news.Add(_dosagemAppService.Incluir(new DosagemViewModel
                    {
                        TratamentoId = model.Id,
                        Intervalo = r.Intervalo,
                        Quantidade = r.Quantidade,
                        MedicamentoId = r.MedicamentoId
                    }));
                }

            model.DosagemSet = news;

            return model;
        }

        public override TratamentoViewModel Atualizar(TratamentoViewModel model)
        {
            var DosagemSet = model.DosagemSet.ToList() ?? new List<DosagemViewModel> { };
            model.DosagemSet = null;

            model = base.Atualizar(model);

            model.DosagemSet = DosagemSet;

            var inteiros = model.DosagemSet.Select(s => s.Id).ToList();

            var retirar = _dosagemAppService.Filtrar(f => f.TratamentoId == model.Id && !inteiros.Contains(f.Id)).ToList();
            foreach (var r in retirar)
                _dosagemAppService.Remover(r);

            var update = model.DosagemSet.Where(f => f.Id > 0).ToList();
            foreach (var u in update)
            {
                u.TratamentoId = model.Id;
                _dosagemAppService.Atualizar(u);
            }

            foreach (var r in model.DosagemSet.Where(w => !(w.Id > 0)))
                _dosagemAppService.Incluir(new DosagemViewModel
                {
                    TratamentoId = model.Id,
                    Intervalo = r.Intervalo,
                    Quantidade = r.Quantidade,
                    MedicamentoId = r.MedicamentoId
                });

            return model;
        }

        public override void Remover(TratamentoViewModel model)
        {
            var entity = Service.Find(f => f.Id == model.Id && f.RECDELETEDON == null).SingleOrDefault();
            if (entity == null)
                throw new NoRecordsFoundException("Registro não encontrado");

            foreach (var x in entity.DosagemSet)
            {
                entity.RECDELETEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null;

                _dosagemService.Delete(x);
            }

            entity.RECDELETEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null;

            Service.Delete(entity);
        }

    }
}
