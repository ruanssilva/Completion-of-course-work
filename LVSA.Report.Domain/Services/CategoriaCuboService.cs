using LVSA.Base.Domain.Services;
using LVSA.Report.Domain.Interfaces.Repository;
using LVSA.Report.Domain.Interfaces.Services;
namespace LVSA.Report.Domain.Services
{
    public class CategoriaCuboService : ServiceBase<CategoriaCubo>, ICategoriaCuboService
    {
        public CategoriaCuboService(ICategoriaCuboRepository categoriaCuboRepository)
            : base(categoriaCuboRepository)
        {
        }
    }
}
