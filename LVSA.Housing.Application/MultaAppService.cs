using LVSA.Housing.Application.Interfaces;
using LVSA.Housing.Application.ViewModels;
using LVSA.Housing.Domain;
using LVSA.Housing.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Application
{
    public class MultaAppService : AppServiceBase<MultaViewModel, Multa, IMultaService>, IMultaAppService
    {
        public MultaAppService(IMultaService multaService)
            : base(multaService)
        {

        }

        public override IEnumerable<MultaViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public MultaViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }
    }
}
