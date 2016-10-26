using LVSA.Global.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LVSA.Global.Presentation.ViewModels
{
    public class PessoaFisicaComplementoAppViewModel : PessoaFisicaComplementoViewModel
    {
        [Display(Name = "Foto")]
        public HttpPostedFileBase File { get; set; }
        public byte[] Imagem { get; set; }

        public PessoaFisicaComplementoAppViewModel(PessoaFisicaComplementoViewModel parent)
        {
            if (parent != null)
            {
                this.CidadeNaturalidade = parent.CidadeNaturalidade;
                this.CidadeNaturalidadeId = parent.CidadeNaturalidadeId;
                this.Email = parent.Email;
                this.Escolaridade = parent.Escolaridade;
                this.EscolaridadeId = parent.EscolaridadeId;
                this.Facebook = parent.Facebook;
                this.GooglePlus = parent.GooglePlus;
                this.Instagram = parent.Instagram;
                this.Pessoa = parent.Pessoa;
                this.PessoaId = parent.PessoaId;
                this.RacaCor = parent.RacaCor;
                this.RacaCorId = parent.RacaCorId;
                this.Telefone1 = parent.Telefone1;
                this.Telefone2 = parent.Telefone2;
                this.Titulacao = parent.Titulacao;
                this.TitulacaoId = parent.TitulacaoId;
                this.Twitter = parent.Twitter;
                this.UsuarioId = parent.UsuarioId;
            }
        }

        public PessoaFisicaComplementoAppViewModel()
        {

        }
    }
}