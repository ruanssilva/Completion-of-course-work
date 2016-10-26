using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Application.ViewModels
{
    public class AnimalViewModel
    {
        public long Id { get; set; }
        public int? RacaId { get; set; }
        public int TipoAnimalId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int? Quantidade { get; set; }
        public DateTime? Nascimento { get; set; }
        public decimal? Peso { get; set; }
        public decimal? Comprimento { get; set; }
        public decimal? Largura { get; set; }
        public string Observacao { get; set; }
        public IEnumerable<RetratoViewModel> RetratoSet { get; set; }
        public IEnumerable<MedicacaoViewModel> MedicacaoSet { get; set; }
        public RacaViewModel Raca { get; set; }
        public TipoAnimalViewModel TipoAnimal { get; set; }
    }
}
