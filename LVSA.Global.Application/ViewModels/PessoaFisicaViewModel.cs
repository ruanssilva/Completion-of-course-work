using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Global.Application.ViewModels
{
    public class PessoaFisicaViewModel : PessoaViewModel
    {
        [Display(Name = "Data de nascimento")]
        public DateTime? DataNascimento { get; set; }
        [Display(Name = "Masculino")]
        public bool? Masculino { get; set; }
        [MaxLength(14)]
        [Display(Name = "CPF.")]
        public string Cpf { get; set; }
        [MaxLength(14)]
        [Display(Name = "RG.")]
        public string Rg { get; set; }
        public PessoaFisicaComplementoViewModel PessoaComplemento { get; set; }
        [Display(Name = "Sexo")]
        public char Sexo
        {
            get { return Masculino == null ? ' ' : (Masculino == true ? 'M' : 'F'); }
            set { Masculino = (value == 'M' || value == 'F') ? value == 'M' : Masculino; }
        }
    }
}
