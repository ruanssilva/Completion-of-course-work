using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Application.ViewModels
{
    public class MoradiaViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Bloco")]
        public int? BlocoId { get; set; }
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

        public IEnumerable<MoradorViewModel> Moradores { get; set; }

        [Display(Name = "Nº de moradores")]
        public int NumeroMoradores { get { return Moradores != null ? Moradores.Where(w => w.Ativo).Count() : 0; } }

        public virtual CondominioViewModel Condominio { get; set; }
        public virtual BlocoViewModel Bloco { get; set; }
    }
}
