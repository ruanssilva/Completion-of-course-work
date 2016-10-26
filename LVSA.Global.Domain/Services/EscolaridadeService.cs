using LVSA.Base.Domain.Services;
using LVSA.Global.Domain.Interfaces.Repository;
using LVSA.Global.Domain.Interfaces.Services;

namespace LVSA.Global.Domain.Services
{
    public class EscolaridadeService : ServiceBase<Escolaridade>, IEscolaridadeService
    {
        private readonly IEscolaridadeRepository _repository;
        public EscolaridadeService(IEscolaridadeRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
