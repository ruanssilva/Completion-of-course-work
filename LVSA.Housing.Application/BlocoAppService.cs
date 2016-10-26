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
    public class BlocoAppService : AppServiceBase<BlocoViewModel, Bloco, IBlocoService>, IBlocoAppService
    {
        private readonly ISindicoAppService _sindicoAppService;

        public BlocoAppService(IBlocoService blocoService, ISindicoAppService sindicoAppService)
            : base(blocoService)
        {
            _sindicoAppService = sindicoAppService;
        }

        public override IEnumerable<BlocoViewModel> Filtrar(Expression<Func<Bloco, bool>> predicate)
        {
            IEnumerable<BlocoViewModel> model = base.Filtrar(predicate);

            model = model.Select(s =>
            {
                s.Sindico = s.SindicoId > 0 ? _sindicoAppService.ObterPorId((int)s.SindicoId) : s.Sindico;

                return s;
            });

            return model;
        }

        public override IEnumerable<BlocoViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public BlocoViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }
    }
}
