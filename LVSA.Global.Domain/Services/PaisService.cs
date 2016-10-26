using LVSA.Base.Domain.Services;
using LVSA.Global.Domain.Interfaces.Repository;
using LVSA.Global.Domain.Interfaces.Services;

namespace LVSA.Global.Domain.Services
{
    public class PaisService: ServiceBase<Pais>, IPaisService
    {
        private readonly IPaisRepository _repository;
        public PaisService(IPaisRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
