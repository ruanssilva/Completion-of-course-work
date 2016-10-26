using System;
using System.ComponentModel.DataAnnotations;

namespace LVSA.Global.Application.ViewModels
{
    public class PessoaJuridicaViewModel : PessoaViewModel
    {
        [MaxLength(65)]
        [Display(Name="Razão Social")]
        public string RazaoSocial { get; set; }
        [MaxLength(18)]
        [Display(Name = "CNPJ.")]
        public string Cnpj { get; set; }
        [MaxLength(65)]
        [Display(Name = "Inscrição estadual")]        
        public string InscricaoEstadual { get; set; }
        [MaxLength(65)]
        [Display(Name = "Inscrição municipal")]
        public string InscricaoMunicipal { get; set; }
        [Display(Name = "Data de fundação")]
        public DateTime? DataFundacao { get; set; }
    }
}
