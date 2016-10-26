using LVSA.Report.Application.Interfaces;
using LVSA.Report.Application.ViewModels;
using LVSA.Report.Domain;
using LVSA.Report.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace LVSA.Report.Application
{
    public class CategoriaCuboAppService : AppServiceBase<CategoriaCuboViewModel, CategoriaCubo, ICategoriaCuboService>, ICategoriaCuboAppService
    {
        public CategoriaCuboAppService(ICategoriaCuboService categoriaCuboService)
            : base(categoriaCuboService)
        {

        }

        public override IEnumerable<CategoriaCuboViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public CategoriaCuboViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }
    }
}
