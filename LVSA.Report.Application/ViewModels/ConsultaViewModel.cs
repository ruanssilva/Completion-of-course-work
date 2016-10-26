using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Application.ViewModels
{
    public class ConsultaViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(65)]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        [Required]
        [Display(Name = "Categoria da consulta")]
        public int CategoriaConsultaId { get; set; }
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
        [Required]
        [Display(Name = "TSQL")]
        public string TSQL { get; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public List<CuboViewModel> Cubos { get; set; }
        public List<ParametroViewModel> Parametros { get; set; }
        public CategoriaConsultaViewModel CategoriaConsulta { get; set; }
        public int Rows { get; set; }
    }
}
