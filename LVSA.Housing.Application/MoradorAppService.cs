using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
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
    public class MoradorAppService : AppServiceBase<MoradorViewModel, Morador, IMoradorService>, IMoradorAppService
    {
        private readonly IPessoaFisicaAppService _pessoaFisicaAppService;

        public MoradorAppService(IMoradorService moradorService, IPessoaFisicaAppService pessoaFisicaAppService)
            : base(moradorService)
        {
            _pessoaFisicaAppService = pessoaFisicaAppService;
        }

        public override IEnumerable<MoradorViewModel> Filtrar(System.Linq.Expressions.Expression<Func<Morador, bool>> predicate)
        {
            IEnumerable<MoradorViewModel> model = base.Filtrar(predicate);

            List<int> moradores = model.Select(s => s.PessoaId).ToList();

            IEnumerable<PessoaFisicaViewModel> pessoas = _pessoaFisicaAppService.Filtrar(f => moradores.Contains(f.Id));

            model = model.Select(s =>
            {
                s.Pessoa = pessoas.Where(w => w.Id == s.PessoaId).SingleOrDefault();

                return s;
            });

            return model.Where(w => w.Pessoa != null);
        }

        public override IEnumerable<MoradorViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public MoradorViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }
    }
}
