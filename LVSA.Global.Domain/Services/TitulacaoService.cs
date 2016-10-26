using LVSA.Base.Domain.Services;
using LVSA.Global.Domain.Interfaces.Repository;
using LVSA.Global.Domain.Interfaces.Services;

namespace LVSA.Global.Domain.Services
{
    public class TitulacaoService : ServiceBase<Titulacao>, ITitulacaoService
    {
        private readonly ITitulacaoRepository _repository;
        public TitulacaoService(ITitulacaoRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
