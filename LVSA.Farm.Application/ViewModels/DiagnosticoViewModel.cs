using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Application.ViewModels
{
    public class DiagnosticoViewModel
    {
        public long Id { get; set; }
        public long AnimalId { get; set; }
        public int? DoencaId { get; set; }
        public string Observacao { get; set; }
        public DateTime DataDiagnostico { get; set; }
        public virtual AnimalViewModel Animal { get; set; }
        public virtual DoencaViewModel Doenca { get; set; }
        public IEnumerable<RetratoViewModel> RetratoSet { get; set; }
    }
}
