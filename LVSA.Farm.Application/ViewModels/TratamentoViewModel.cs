using LVSA.Base.Application.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Application.ViewModels
{
    public class TratamentoViewModel
    {
        public long Id { get; set; }
        [Obrigatorio]
        public string Nome { get; set; }
        public int? DoencaId { get; set; }
        [Obrigatorio]
        public string Descricao { get; set; }
        [Range(1, 999)]
        public int Dias { get; set; }
        public bool Ativo { get; set; }
        public DoencaViewModel Doenca { get; set; }
        public IEnumerable<DosagemViewModel> DosagemSet { get; set; }
    }
}
