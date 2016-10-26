using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Financial.Application.ViewModels
{
    public class NFiscalViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Empresa")]
        public int? EmpresaId { get; set; }
        [Required]
        [Display(Name = "Data de emissão")]
        public DateTime DataEmissao { get; set; }
        [Required]
        [Display(Name = "Número")]
        public string Numero { get; set; }
        [Required]
        [Display(Name = "Série")]
        public string Serie { get; set; }
        [Display(Name = "Nome fantasia")]
        public string NomeFantasia { get; set; }
        [Display(Name = "Razão social")]
        public string RazaoSocial { get; set; }
        [Display(Name = "Inscrição estadual")]
        public string InscricaoEstadual { get; set; }
        [Display(Name = "Inscrição municipal")]
        public string InscricaoMunicipal { get; set; }
        [Display(Name = "CNPJ.")]
        public string Cnpj { get; set; }
        [Required]
        [Display(Name = "Valor total")]
        public Decimal ValorTotal { get; set; }
        public byte[] Anexo { get; set; }

        public string Nome
        {
            get
            {
                return string.Format("{0} emitida em {1} nº{2}",
                    this.ValorTotal,
                    this.DataEmissao.ToShortDateString(),
                    this.Numero);
            }
        }

    }
}
