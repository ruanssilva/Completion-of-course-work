using AutoMapper;
using LVSA.Housing.Application.Interfaces;
using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Domain;
using LVSA.Housing.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Application
{
    public class MultaMoradorAppService : AppServiceBase<MultaMoradorViewModel, MultaMorador, IMultaMoradorService>, IMultaMoradorAppService
    {
        private readonly IMoradorAppService _moradorAppService;

        public MultaMoradorAppService(IMultaMoradorService multaMoradorService, IMoradorAppService moradorAppService)
            : base(multaMoradorService)
        {
            _moradorAppService = moradorAppService;
        }

        public override IEnumerable<MultaMoradorViewModel> Filtrar(System.Linq.Expressions.Expression<Func<MultaMorador, bool>> predicate)
        {
            IEnumerable<MultaMoradorViewModel> model = base.Filtrar(predicate);

            List<int> MoradorIds = model.Select(s => s.MoradorId).Distinct().ToList();

            IEnumerable<MoradorViewModel> moradores = _moradorAppService.Filtrar(f => MoradorIds.Contains(f.Id));

            foreach (var s in model)
            {
                s.Morador = moradores.Where(w => w.Id == s.MoradorId).SingleOrDefault();

            }
            
            return model;
        }



        public override IEnumerable<MultaMoradorViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public MultaMoradorViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }

        public override MultaMoradorViewModel Atualizar(MultaMoradorViewModel model)
        {
            MultaMorador entity = Service.Find(f => f.Id == model.Id).SingleOrDefault();

            if (entity.ColigadaId != Seguranca.ColigadaId || entity.FilialId != Seguranca.FilialId)
                throw new FieldAccessException();

            entity.DataPagamento = model.DataPagamento;
            entity.Juros = model.Juros;

            Service.Update(entity);

            return Mapper.Map<MultaMorador, MultaMoradorViewModel>(entity);
        }
    }
}
