using LVSA.Housing.Application.Interfaces;
using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Domain;
using LVSA.Housing.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Application
{
    public class MoradiaAppService : AppServiceBase<MoradiaViewModel, Moradia, IMoradiaService>, IMoradiaAppService
    {
        private readonly IMoradorAppService _moradorAppService;

        public MoradiaAppService(IMoradiaService moradiaService, IMoradorAppService moradorAppService)
            : base(moradiaService)
        {
            _moradorAppService = moradorAppService;
        }

        public override IEnumerable<MoradiaViewModel> Filtrar(Expression<Func<Moradia, bool>> predicate)
        {
            IEnumerable<MoradiaViewModel> model = base.Filtrar(predicate);

            List<int> moradias = model.Select(s => s.Id).ToList();

            IEnumerable<MoradorViewModel> moradores = _moradorAppService.Filtrar(f => moradias.Contains(f.MoradiaId));

            model = model.Select(s =>
            {
                s.Moradores = moradores.Where(w => w.MoradiaId == s.Id);
                return s;
            });

            return model;
        }

        public MoradiaViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }

        public override IEnumerable<MoradiaViewModel> Todos()
        {
            return Filtrar(f => true);
        }
    }
}
