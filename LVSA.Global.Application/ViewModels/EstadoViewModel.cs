using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Global.Application.ViewModels
{
    public class EstadoViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "País")]
        public int PaisId { get; set; }
        [Required]
        [MaxLength(65)]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        [Required]
        [MaxLength(65)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required]
        [MaxLength(2)]
        [Display(Name = "Sigla")]
        public string SiglaUF { get; set; }
        public IEnumerable<CidadeViewModel> Cidades { get; set; }
        public PaisViewModel Pais { get; set; }
    }
}
