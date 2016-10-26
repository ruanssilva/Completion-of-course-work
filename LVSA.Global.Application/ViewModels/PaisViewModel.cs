using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Global.Application.ViewModels
{
    public class PaisViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(65)]
        [Display(Name="Nome")]
        public string Nome { get; set; }
        [Required]
        [MaxLength(3)]
        [Display(Name = "Sigla")]
        public string Sigla { get; set; }
        public IEnumerable<EstadoViewModel> Estados { get; set; }
    }
}
