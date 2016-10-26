using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Application.ViewModels
{
    public class TipoAnimalViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<RacaViewModel> RacaSet { get; set; }
        public IEnumerable<RetratoViewModel> RetratoSet { get; set; }
    }
}
