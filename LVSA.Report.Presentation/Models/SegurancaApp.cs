using LVSA.Report.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LVSA.Report.Presentation.Models
{
    public class SegurancaApp
    {
        public string Id { get; set; }
        public DateTime UltimaAtividade { get; set; }

        public List<GrupoViewModel> Grupos { get; set; }

        public List<CuboViewModel> Cubos
        {
            get
            {
                return Grupos != null ? Grupos.SelectMany(sm => sm.Cubos).Where(w => w.Ativo).GroupBy(gb => gb.Id).Select(s => s.First()).ToList() : new List<CuboViewModel> { };
            }
        }
    }
}