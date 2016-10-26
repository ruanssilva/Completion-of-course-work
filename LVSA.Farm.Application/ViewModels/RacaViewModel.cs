using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Application.ViewModels
{
    public class RacaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int TipoAnimalId { get; set; }
        public bool Ativo { get; set; }
        public virtual TipoAnimalViewModel TipoAnimal { get; set; }
        public virtual IEnumerable<RetratoViewModel> RetratoSet { get; set; }
    }
}
