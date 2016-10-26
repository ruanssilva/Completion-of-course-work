using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Farm.Application.ViewModels
{
    public class OrdenhaViewModel
    {
        public long Id { get; set; }
        public DateTime Horario { get; set; }
        public long AnimalId { get; set; }
        public decimal Quantidade { get; set; }
        public string Observacao { get; set; }
        public AnimalViewModel Animal { get; set; }
    }
}
