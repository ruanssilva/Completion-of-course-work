using LVSA.Global.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Application.ViewModels
{
    public class SindicoViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Pessoa")]
        public int PessoaId { get; set; }
        public PessoaFisicaViewModel Pessoa { get; set; }
        public IEnumerable<BlocoViewModel> Blocos { get; set; }
        public CondominioViewModel Condominio { get; set; }
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

        [Display(Name = "Coligada")]
        public int ColigadaId { get; set; }
        [Display(Name = "Filial")]
        public int FilialId { get; set; }
    }
}
