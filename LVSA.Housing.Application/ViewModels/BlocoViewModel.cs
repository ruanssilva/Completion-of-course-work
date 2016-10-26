using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Application.ViewModels
{
    public class BlocoViewModel
    {
        public int Id { get; set; }
        [Display(Name="Síndico")]
        public int? SindicoId { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Sigla")]
        public string Sigla { get; set; }
        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
        public CondominioViewModel Condominio { get; set; }
        public SindicoViewModel Sindico { get; set; }
        public IEnumerable<MoradiaViewModel> Moradias { get; set; }
        
    }
}
