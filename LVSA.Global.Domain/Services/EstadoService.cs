using LVSA.Base.Domain.Services;
using LVSA.Global.Domain.Interfaces.Repository;
using LVSA.Global.Domain.Interfaces.Services;

namespace LVSA.Global.Domain.Services
{
    public class EstadoService : ServiceBase<Estado>, IEstadoService
    {
        private readonly IEstadoRepository _repository;
        public EstadoService(IEstadoRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
