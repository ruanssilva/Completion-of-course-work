using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LVSA.Report.Application.ViewModels
{
    public class InstrucaoViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(65)]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        [Required]
        [Display(Name = "Instrução")]
        public string Code { get; set; }
        [Required]
        [Display(Name = "Categoria da instrução")]
        public int CategoriaInstrucaoId { get; set; }
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
        [MaxLength(255)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public List<CuboViewModel> Cubos { get; set; }
        public CategoriaInstrucaoViewModel CategoriaInstrucao { get; set; }
    }
}
