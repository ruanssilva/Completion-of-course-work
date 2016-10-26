using LVSA.Report.Application.Interfaces;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Collections;
using System.Linq;
using LVSA.Base.Presentation.Controllers;
using LVSA.Base.Presentation.ViewModels;
using System.Web.Mvc;
using LVSA.Report.Application.ViewModels;
using LVSA.Security.Application.Models;
using LVSA.Base.Application.Interfaces;

namespace LVSA.Report.Presentation.ViewModels
{
    public class ReportViewModel
    {
        private readonly IReadOnlyAppService _readOnlyAppService;
        private readonly Seguranca _seguranca;
        public ReportViewModel(IReadOnlyAppService readOnlyAppService, Seguranca seguranca = null)
        {
            _readOnlyAppService = readOnlyAppService;
            _seguranca = seguranca;
        }
        private List<ParametroViewModel> _parametros { get; set; }
        public List<ParametroViewModel> Parametros { get { return _parametros ?? new List<ParametroViewModel> { }; } set { _parametros = value; } }
        private string _tsql { get; set; }
        public string TSQL
        {
            get
            {
                return string.Format(_tsql
                    .Replace("$UsuarioId", _seguranca != null ? _seguranca.CODUSUARIO.ToString() : "")
                    .Replace("$ColigadaId", _seguranca != null ? _seguranca.ColigadaId.ToString() : "")
                    .Replace("$FilialId", _seguranca != null ? _seguranca.FilialId.ToString() : "")

                , Parametros.OrderBy(o => o.Numero).Select(s => s.Valor).ToArray());
            }
            set { _tsql = value; }
        }
        private int _rows { get; set; }
        public int Rows { get { return _rows; } }
        private List<GritterViewModel> _Gritters { get; set; }
        public List<GritterViewModel> Gritters { get { return _Gritters ?? new List<GritterViewModel> { }; } set { _Gritters = value; } }
        public string View { get; set; }
        public dynamic Model { get; set; }
        public WebGrid WebGrid { get; set; }
        public WebGridColumn[] WebGridColumns { get; set; }
        public WebGrid WebGraph { get; set; }
        public WebGridColumn[] WebGraphColumns { get; set; }


        public IEnumerable<TEntity> GetSource<TEntity>()
        {
            var source = _readOnlyAppService.Query<TEntity>(this.TSQL);

            _rows = source.Count();

            return source;
        }

        public IEnumerable<TEntity> GetSource<TEntity>(string tsql)
        {
            var source = _readOnlyAppService.Query<TEntity>(tsql);

            _rows = source.Count();

            return source;
        }

    }
}