using LVSA.Financial.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LVSA.Financial.Presentation.ViewModels
{
    public class LancamentoAppViewModel : LancamentoViewModel
    {
        public IEnumerable<LancamentoViewModel> LancamentoSet { get; set; }
        [Display(Name = "Início")]
        public DateTime? DataFiltroInicio { get; set; }
        [Display(Name = "Final")]
        public DateTime? DataFiltroFinal { get; set; }
        [Display(Name = "Entrada")]
        public bool? Entrada { get; set; }
        [Display(Name = "Centro de custo")]
        public int? CCustoId { get; set; }

        public LancamentoAppViewModel()
        {

        }

        public LancamentoAppViewModel(LancamentoViewModel parent)
        {
            if (parent != null)
            {
                this.CCusto = parent.CCusto;
                this.CCustoId = parent.CCustoId;
                this.DataLancamento = parent.DataLancamento;
                this.Descricao = parent.Descricao;
                this.Id = parent.Id;
                this.NFiscal = parent.NFiscal;
                this.NFiscalId = parent.NFiscalId;
                this.Valor = parent.Valor;                
            }
        }
    }
}