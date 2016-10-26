using LVSA.Financial.Application.Interfaces;
using LVSA.Financial.Application.ViewModels;
using LVSA.Financial.Domain;
using LVSA.Financial.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace LVSA.Financial.Application
{
    public class CategoriaCCustoAppService : AppServiceBase<CategoriaCCustoViewModel,CategoriaCCusto,ICategoriaCCustoService>, ICategoriaCCustoAppService
    {
        public CategoriaCCustoAppService(ICategoriaCCustoService categoriaCCustoService)
            : base(categoriaCCustoService)
        {
            
        }

        public override IEnumerable<CategoriaCCustoViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public CategoriaCCustoViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }
    }
}
