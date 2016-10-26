using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Application.ViewModels
{
    public class TerrenoViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal? M2 { get; set; }
        public decimal? Largura { get; set; }
        public decimal? Comprimento { get; set; }
        public IEnumerable<PastoViewModel> PastoSet { get; set; }
        public IEnumerable<RetratoViewModel> RetratoSet { get; set; }
    }
}
