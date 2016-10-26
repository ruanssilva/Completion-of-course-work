using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LVSA.Report.Application.ViewModels
{
    public class CuboViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Código")]
        public string Codigo { get; set; }
        [Required]
        [Display(Name = "Consulta")]
        public int ConsultaId { get; set; }
        [Required]
        [Display(Name = "Instrução")]
        public int InstrucaoId { get; set; }
        [Required]
        [Display(Name = "Categoria do cubo")]
        public int CategoriaCuboId { get; set; }
        [Required]
        [MaxLength(65)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [MaxLength(65)]
        [Display(Name = "Ícone")]
        public string Icon { get; set; }
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
        public ConsultaViewModel Consulta { get; set; }
        public InstrucaoViewModel Instrucao { get; set; }
        public CategoriaCuboViewModel CategoriaCubo { get; set; }

        public bool Acesso { get; set; }
        public bool ShowResult { get; set; }
        public double Time { get; set; }
        public int Rows { get; set; }
    }
}
