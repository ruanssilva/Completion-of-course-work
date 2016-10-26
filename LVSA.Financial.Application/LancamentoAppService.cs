using LVSA.Base.Application.Exceptions;
using LVSA.Financial.Application.Interfaces;
using LVSA.Financial.Application.ViewModels;
using LVSA.Financial.Domain;
using LVSA.Financial.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LVSA.Financial.Application
{
    public class LancamentoAppService : AppServiceBase<LancamentoViewModel,Lancamento,ILancamentoService>, ILancamentoAppService
    {
        public LancamentoAppService(ILancamentoService lancamentoService)
            : base(lancamentoService)
        {

        }

        public override IEnumerable<LancamentoViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public override LancamentoViewModel Incluir(LancamentoViewModel model)
        {
            model.DataLancamento = DateTime.Now;

            return base.Incluir(model);
        }

        public LancamentoViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }

        public override void Remover(LancamentoViewModel model)
        {
            var entity = Service.Find(f => f.Id == model.Id && f.RECDELETEDON == null).SingleOrDefault();
            if (entity == null)
                throw new NoRecordsFoundException("Recurso não encontrado");

            entity.RECDELETEDBY = Seguranca != null ? Seguranca.CODUSUARIO : null;

            Service.Delete(entity);
        }
    }
}
