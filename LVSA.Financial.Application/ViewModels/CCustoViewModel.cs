using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Financial.Application.ViewModels
{
    public class CCustoViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Categoria")]
        public int? CategoriaCCustoId { get; set; }
        [Required]
        [MaxLength(65)]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        [Required]
        [MaxLength(65)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Required]
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
        public CategoriaCCustoViewModel CategoriaCCusto { get; set; }
    }
}
