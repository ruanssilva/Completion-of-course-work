using LVSA.Housing.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LVSA.Housing.Presentation.ViewModels
{
    public class CustoMoradiaAppViewModel : CustoMoradiaViewModel
    {
        public IEnumerable<CustoMoradiaViewModel> CustoMoradiaSet { get; set; }
        [Display(Name = "Início")]
        public DateTime? DataFiltroInicio { get; set; }
        [Display(Name = "Final")]
        public DateTime? DataFiltroFinal { get; set; }
        [Display(Name = "Moradias")]
        public int[] MoradiaIdSet { get; set; }
        [Display(Name = "Baixado")]
        public bool? FiltroPago { get; set; }
        [Display(Name = "Centro de custo")]
        public int CCustoId { get; set; }

        [Display(Name ="Custo rateado?")]
        public bool Rateado { get; set; }

        public CustoMoradiaAppViewModel()
        {

        }

        public CustoMoradiaAppViewModel(CustoMoradiaViewModel parent)
        {
            if (parent != null)
            {
                this.Id = parent.Id;
                this.Descricao = parent.Descricao;
                this.Juros = parent.Juros;
                this.Desconto = parent.Desconto;
                this.MoradiaId = parent.MoradiaId;
                this.Valor = parent.Valor;
                this.Moradia = parent.Moradia;
                this.DataVencimento = parent.DataVencimento;
                this.DataReferencia = parent.DataReferencia;
                this.DataPagamento = parent.DataPagamento;
            }
        }
    }
}