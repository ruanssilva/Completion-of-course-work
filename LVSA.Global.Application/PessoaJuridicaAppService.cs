using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using LVSA.Global.Domain;
using LVSA.Global.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace LVSA.Global.Application
{
    public class PessoaJuridicaAppService : AppServiceBase<PessoaJuridicaViewModel, PessoaJuridica, IPessoaJuridicaService>, IPessoaJuridicaAppService
    {
        public PessoaJuridicaAppService(IPessoaJuridicaService pessoaJuridicaService)
            : base(pessoaJuridicaService)
        {

        }

        public override IEnumerable<PessoaJuridicaViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public PessoaJuridicaViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }
    }
}
