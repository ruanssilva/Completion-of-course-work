using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Global.Application.ViewModels
{
    public class BairroViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Nome")]
        [MaxLength(65)]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }
        public CidadeViewModel Cidade { get; set; }
    }
}
