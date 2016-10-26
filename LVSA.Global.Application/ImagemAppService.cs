using LVSA.Global.Application.Interfaces;
using LVSA.Global.Application.ViewModels;
using LVSA.Global.Domain;
using LVSA.Global.Domain.Interfaces.Services;

namespace LVSA.Global.Application
{
    public class ImagemAppService : AppServiceBase<ImagemViewModel, Imagem, IImagemService>, IImagemAppService
    {
        public ImagemAppService(IImagemService imagemService)
            : base(imagemService)
        {

        }
    }
}
