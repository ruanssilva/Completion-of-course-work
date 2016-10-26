using LVSA.Global.Application.Interfaces;
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
    public class SindicoAppService : AppServiceBase<SindicoViewModel, Sindico, ISindicoService>, ISindicoAppService
    {
        private readonly IPessoaFisicaAppService _pessoaFisicaAppService;

        public SindicoAppService(ISindicoService sindicoService, IPessoaFisicaAppService pessoaFisicaAppService)
            : base(sindicoService)
        {
            _pessoaFisicaAppService = pessoaFisicaAppService;
        }

        public override IEnumerable<SindicoViewModel> Filtrar(Expression<Func<Sindico, bool>> predicate)
        {
            IEnumerable<SindicoViewModel> model = base.Filtrar(predicate).ToList();

            var ids = model.Select(s => s.PessoaId).ToArray();

            var pessoas = _pessoaFisicaAppService.Filtrar(f => ids.Contains(f.Id)).ToList();

            model = model.Select(s =>
            {
                s.Pessoa = pessoas.Where(w => w.Id == s.PessoaId).SingleOrDefault();

                return s;
            });

            return model.Where(w => w.Pessoa != null);
        }

        public SindicoViewModel ObterPorId(int id)
        {
            return Filtrar(f=>f.Id == id).SingleOrDefault();
        }

        public override IEnumerable<SindicoViewModel> Todos()
        {
            return Filtrar(f => true);
        }

    }
}
