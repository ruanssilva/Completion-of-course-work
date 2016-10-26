using LVSA.Base.Domain.Services;
using LVSA.Global.Domain.Interfaces.Repository;
using LVSA.Global.Domain.Interfaces.Services;

namespace LVSA.Global.Domain.Services
{
    public class FilialComplementoService : ServiceBase<FilialComplemento>, IFilialComplementoService
    {
        private readonly IFilialComplementoRepository _repository;
        public FilialComplementoService(IFilialComplementoRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
