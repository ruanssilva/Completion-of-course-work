using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Global.Application.ViewModels
{
    public class PessoaFisicaComplementoViewModel
    {
        [Required]
        [Display(Name="Pessoa")]
        public int PessoaId { get; set; }
        public PessoaFisicaViewModel Pessoa { get; set; }
        [Display(Name = "Usuário")]
        public long? UsuarioId { get; set; }
        [MaxLength(65)]
        [Display(Name = "Facebook")]
        public string Facebook { get; set; }
        [MaxLength(65)]
        [Display(Name = "Twitter")]
        public string Twitter { get; set; }
        [MaxLength(65)]
        [Display(Name = "Instagram")]
        public string Instagram { get; set; }
        [MaxLength(65)]
        [Display(Name = "g+")]
        public string GooglePlus { get; set; }
        [Display(Name = "Raça/Cor")]
        public int? RacaCorId { get; set; }
        public RacaCorViewModel RacaCor { get; set; }
        [Display(Name = "Naturalidade")]
        public int? CidadeNaturalidadeId { get; set; }
        public CidadeViewModel CidadeNaturalidade { get; set; }
        [MaxLength(15)]
        [Display(Name = "Telefone")]
        public string Telefone1 { get; set; }
        [MaxLength(15)]
        [Display(Name = "Celular")]
        public string Telefone2 { get; set; }
        [MaxLength(65)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Escolaridade")]
        public int? EscolaridadeId { get; set; }
        public EscolaridadeViewModel Escolaridade { get; set; }
        [Display(Name = "Titulação")]
        public int? TitulacaoId { get; set; }
        public TitulacaoViewModel Titulacao { get; set; }
        [Display(Name = "Foto")]
        public int? ImagemId { get; set; }
        public ImagemViewModel Imagem { get; set; }
    }
}
