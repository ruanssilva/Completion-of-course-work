using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Financial.Application.ViewModels
{
    public class LancamentoViewModel
    {
        public int Id { get; set; }
        [Display(Name="Notal fiscal")]
        public int? NFiscalId { get; set; }
        [Display(Name = "Centro de custo")]
        public int CCustoId { get; set; }
        [Required]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }
        [Required]
        [Display(Name = "Data de lançamento")]
        public DateTime DataLancamento { get; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public virtual CCustoViewModel CCusto { get; set; }
        public virtual NFiscalViewModel NFiscal { get; set; }
    }
}
