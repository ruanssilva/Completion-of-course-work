using AutoMapper;
using LVSA.Base.Application.Interfaces;
using LVSA.Report.Application.Interfaces;
using LVSA.Report.Application.ViewModels;
using LVSA.Report.Domain;
using LVSA.Report.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace LVSA.Report.Application
{
    public class ConsultaAppService : AppServiceBase<ConsultaViewModel, Consulta, IConsultaService>, IConsultaAppService
    {
        private readonly IConsultaParametroService _consultaParametroService;
        private readonly IReadOnlyAppService _readOnlyAppService;

        public ConsultaAppService(IConsultaService consultaService, IConsultaParametroService consultaParametroService, IReadOnlyAppService readOnlyAppService)
            : base(consultaService)
        {
            _consultaParametroService = consultaParametroService;
            _readOnlyAppService = readOnlyAppService;
        }

        public override IEnumerable<ConsultaViewModel> Filtrar(System.Linq.Expressions.Expression<System.Func<Consulta, bool>> predicate)
        {
            IEnumerable<ConsultaViewModel> model = base.Filtrar(predicate);

            foreach (var s in model)
            {
                s.Parametros = _consultaParametroService.Find(f => f.ConsultaId == s.Id).ToList().Select(s1 =>
                {
                    var viewmodel = Mapper.Map<Parametro, ParametroViewModel>(s1.Parametro);

                    viewmodel.Numero = s1.Numero;
                    viewmodel.Valor = string.Empty;
                    viewmodel.Descricao = s1.Descricao;

                    if (!string.IsNullOrEmpty(viewmodel.Consulta))
                    {
                        try
                        {
                            viewmodel.Consulta = viewmodel.Consulta
                                                    .Replace("$UsuarioId", Seguranca != null ? Seguranca.CODUSUARIO.ToString() : "")
                                                    .Replace("$ColigadaId", Seguranca != null ? Seguranca.ColigadaId.ToString() : "")
                                                    .Replace("$FilialId", Seguranca != null ? Seguranca.FilialId.ToString() : "");

                            viewmodel.ValorSet = _readOnlyAppService.Query<ValorViewModel>(viewmodel.Consulta).ToList();
                        }
                        catch
                        {
                            viewmodel.ValorSet = null;
                        }
                    }

                    return viewmodel;
                }).ToList();
            }
                       

            return model;
        }

        public override IEnumerable<ConsultaViewModel> Todos()
        {
            return Filtrar(f => true);
        }

        public ConsultaViewModel ObterPorId(int id)
        {
            return Filtrar(f => f.Id == id).SingleOrDefault();
        }

        public override ConsultaViewModel Incluir(ConsultaViewModel model)
        {
            if (model.Parametros != null)
            {
                var parametros = model.Parametros;

                model = base.Incluir(model);

                foreach (var p in parametros)
                    _consultaParametroService.Add(new ConsultaParametro { ConsultaId = model.Id, ParametroId = p.Id, ColigadaId = (short)Seguranca.ColigadaId, Numero = p.Numero, Descricao = p.Descricao });
            }
            else
                return base.Incluir(model);

            return model;
        }

        public override ConsultaViewModel Atualizar(ConsultaViewModel model)
        {
            IEnumerable<ConsultaParametro> all = _consultaParametroService.Find(f => f.ConsultaId == model.Id).ToList();

            foreach (var d in all)
                _consultaParametroService.Delete(d);

            foreach (var p in model.Parametros)
                _consultaParametroService.Add(new ConsultaParametro { ConsultaId = model.Id, ParametroId = p.Id, ColigadaId = (short)Seguranca.ColigadaId, Numero = p.Numero, Descricao = p.Descricao });

            return base.Atualizar(model);
        }
    }
}
