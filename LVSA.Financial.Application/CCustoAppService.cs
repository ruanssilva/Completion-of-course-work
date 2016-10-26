using LVSA.Base.Application.Exceptions;
using LVSA.Financial.Application.Interfaces;
using LVSA.Financial.Application.ViewModels;
using LVSA.Financial.Domain;
using LVSA.Financial.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace LVSA.Financial.Application
{
    public class CCustoAppService : AppServiceBase<CCustoViewModel, CCusto, ICCustoService>, ICCustoAppService
    {
        public CCustoAppService(ICCustoService cCustoService)
            : base(cCustoService)
        {

        }

        public override IEnumerable<CCustoViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public CCustoViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }

        public override void Remover(CCustoViewModel model)
        {
            var entity = Service.Find(f => f.Id == model.Id && f.RECDELETEDON == null).SingleOrDefault();
            if (entity == null)
                throw new NoRecordsFoundException("Recurso não encontrado");

            entity.RECDELETEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null;

            Service.Delete(entity);
        }
    }
}
