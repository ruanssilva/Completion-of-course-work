using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Global.Application.ViewModels
{
    public class CidadeViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(65)]
        [Display(Name="Código")]
        public string Codigo { get; set; }
        [Required]
        [MaxLength(65)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Estado")]
        public int EstadoId { get; set; }
        public EstadoViewModel Estado { get; set; }
        public IEnumerable<BairroViewModel> Bairros { get; set; }
    }
}
