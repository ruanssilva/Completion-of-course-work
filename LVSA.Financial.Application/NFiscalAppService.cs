using LVSA.Base.Application.Exceptions;
using LVSA.Financial.Application.Interfaces;
using LVSA.Financial.Application.ViewModels;
using LVSA.Financial.Domain;
using LVSA.Financial.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Financial.Application
{
    public class NFiscalAppService : AppServiceBase<NFiscalViewModel,NFiscal,INFiscalService>, INFiscalAppService
    {
        public NFiscalAppService(INFiscalService nFiscalService)
            : base(nFiscalService)
        {

        }

        public override IEnumerable<NFiscalViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public NFiscalViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }

        public override void Remover(NFiscalViewModel model)
        {
            var entity = Service.Find(f => f.Id == model.Id && f.RECDELETEDON == null).SingleOrDefault();
            if (entity == null)
                throw new NoRecordsFoundException("Recurso não encontrado");

            entity.RECDELETEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null;

            Service.Delete(entity);
        }
    }
}
