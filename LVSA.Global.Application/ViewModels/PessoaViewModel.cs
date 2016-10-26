using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Global.Application.ViewModels
{
    public class PessoaViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(65)]
        [Display(Name="Nome")]
        public string Nome { get; set; }
        [MaxLength(65)]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }
        [Display(Name = "Número residencial")]
        public int? NumeroResidencial { get; set; }
        [MaxLength(65)]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }
        [Display(Name = "Bairro")]
        public int? BairroId { get; set; }
        public BairroViewModel Bairro { get; set; }
        [Display(Name = "Cidade")]
        public int? CidadeId { get; set; }
        public CidadeViewModel Cidade { get; set; }
    }
}
