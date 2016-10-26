using LVSA.Base.Application.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LVSA.Farm.Application.ViewModels
{
    public class DosagemViewModel
    {
        public long Id { get; set; }
        public int MedicamentoId { get; set; }
        public long TratamentoId { get; set; }
        [Obrigatorio]
        [Range(0,999)]
        public decimal Quantidade { get; set; }
        [Obrigatorio]
        [Range(1, 999)]
        public int Intervalo { get; set; }
        public virtual MedicamentoViewModel Medicamento { get; set; }
        public virtual TratamentoViewModel Tratamento { get; set; }
    }
}
