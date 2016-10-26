using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Application.ViewModels
{
    public class CondominioViewModel
    {
        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
        public IEnumerable<BlocoViewModel> Blocos { get; set; }
        public IEnumerable<SindicoViewModel> Sindicos { get; set; }
        
    }
}
