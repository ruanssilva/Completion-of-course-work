using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Application.ViewModels
{
    public class CustoMoradiaViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Moradia")]
        public int MoradiaId { get; set; }
        [Required]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }
        [Display(Name = "Valor desconto")]
        public decimal Desconto { get; set; }
        [Display(Name = "Valor juros")]
        public decimal Juros { get; set; }
        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Required]
        [Display(Name = "Data referente")]
        public DateTime DataReferencia { get; set; }
        [Required]
        [Display(Name = "Data de vencimento")]
        public DateTime? DataVencimento { get; set; }
        [Required]
        [Display(Name = "Data de pagamento")]
        public DateTime? DataPagamento { get; set; }
        public MoradiaViewModel Moradia { get; set; }
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
    }
}
