using LVSA.Housing.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LVSA.Housing.Presentation.ViewModels
{
    public class MultaMoradorAppViewModel : MultaMoradorViewModel
    {
        public IEnumerable<MultaMoradorViewModel> MultaMoradorSet { get; set; }
        [Display(Name = "Início")]
        public DateTime? DataFiltroInicio { get; set; }
        [Display(Name = "Final")]
        public DateTime? DataFiltroFinal { get; set; }
        [Display(Name = "Moradores")]
        public int[] MoradorIdSet { get; set; }
        [Display(Name = "Baixado")]
        public bool? FiltroPago { get; set; }
        [Display(Name = "Centro de custo")]
        public int CCustoId { get; set; }

        public MultaMoradorAppViewModel()
        {

        }

        public MultaMoradorAppViewModel(MultaMoradorViewModel parent)
        {
            if (parent != null)
            {
                this.Id = parent.Id;
                this.Multa = parent.Multa;
                this.Descricao = parent.Descricao;
                this.Juros = parent.Juros;
                this.Desconto = parent.Desconto;
                this.MoradorId = parent.MoradorId;
                this.Valor = parent.Valor;
                this.Morador = parent.Morador;
                this.DataVencimento = parent.DataVencimento;
                this.DataReferencia = parent.DataReferencia;
                this.DataPagamento = parent.DataPagamento;
            }
        }
    }
}