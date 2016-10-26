using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using LVSA.Global.Domain;
using LVSA.Global.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace LVSA.Global.Application
{
    public class PessoaFisicaAppService : AppServiceBase<PessoaFisicaViewModel, PessoaFisica, IPessoaFisicaService>, IPessoaFisicaAppService
    {
        private readonly IPessoaFisicaComplementoAppService _pessoaFisicaComplementoAppService;

        public PessoaFisicaAppService(IPessoaFisicaService pessoaFisicaService, IPessoaFisicaComplementoAppService pessoaFisicaComplementoAppService)
            : base(pessoaFisicaService)
        {
            _pessoaFisicaComplementoAppService = pessoaFisicaComplementoAppService;
        }
               

        public override IEnumerable<PessoaFisicaViewModel> Filtrar(System.Linq.Expressions.Expression<System.Func<PessoaFisica, bool>> predicate)
        {
            IEnumerable<PessoaFisicaViewModel> model = base.Filtrar(predicate);

            List<int> pessoas = model.Select(s => s.Id).ToList();

            var complementos = _pessoaFisicaComplementoAppService.Filtrar(f => pessoas.Contains(f.PessoaId));

            model = model.Select(s =>
            {
                s.PessoaComplemento = complementos.Where(w => w.PessoaId == s.Id).SingleOrDefault();

                return s;
            });

            return model;
        }

        public PessoaFisicaViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }

        public override IEnumerable<PessoaFisicaViewModel> Todos()
        {
            return Filtrar(f => true);
        }
    }
}
