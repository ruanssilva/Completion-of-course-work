using LVSA.Base.Domain.Services;
using LVSA.Global.Domain.Interfaces.Repository;
using LVSA.Global.Domain.Interfaces.Services;

namespace LVSA.Global.Domain.Services
{
    public class ImagemService: ServiceBase<Imagem>, IImagemService
    {
        private readonly IImagemRepository _repository;
        public ImagemService(IImagemRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
