using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Application.ViewModels
{
    public class GrupoViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(65)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [MaxLength(255)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
        public bool Selecionado { get; set; }

        public virtual List<CuboViewModel> Cubos { get; set; }
    }
}
