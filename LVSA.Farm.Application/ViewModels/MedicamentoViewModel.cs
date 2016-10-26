using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Application.ViewModels
{
    public class MedicamentoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int TipoMedicamentoId { get; set; }
        public virtual TipoMedicamentoViewModel TipoMedicamento { get; set; }
    }
}
