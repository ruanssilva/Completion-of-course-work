using LVSA.Base.Application;
using LVSA.Report.Application.Interfaces;
using LVSA.Report.Application.ViewModels;
using LVSA.Report.Domain;
using LVSA.Report.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Application
{
    public class ParametroAppService : AppServiceBase<ParametroViewModel, Parametro, IParametroService>, IParametroAppService
    {
        private readonly ReadOnlyAppService _readOnlyAppService;

        public ParametroAppService(IParametroService consultaService, ReadOnlyAppService readOnlyAppService)
            : base(consultaService)
        {
            _readOnlyAppService = readOnlyAppService;
        }

        public override IEnumerable<ParametroViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public ParametroViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }

        public override IEnumerable<ParametroViewModel> Filtrar(System.Linq.Expressions.Expression<Func<Parametro, bool>> predicate)
        {
            IEnumerable<ParametroViewModel> list = base.Filtrar(predicate);



            foreach (ParametroViewModel p in list)
                if (!string.IsNullOrEmpty(p.Consulta))
                {
                    try
                    {
                        p.Consulta = p.Consulta
                                        .Replace("$UsuarioId", Seguranca != null ? Seguranca.CODUSUARIO.ToString() : "")
                                        .Replace("$ColigadaId", Seguranca != null ? Seguranca.ColigadaId.ToString() : "")
                                        .Replace("$FilialId", Seguranca != null ? Seguranca.FilialId.ToString() : "");

                        p.ValorSet = _readOnlyAppService.Query<ValorViewModel>(p.Consulta).ToList();
                    }
                    catch
                    {
                        p.ValorSet = null;
                    }
                }

            return list;
        }
    }
}
