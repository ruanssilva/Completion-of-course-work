using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Housing.Application.ViewModels
{
    public class ReuniaoViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Sindíco")]
        public int SindicoId { get; set; }
        [Required]
        [Display(Name = "Assunto")]
        public string Assunto { get; set; }
        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Required]
        [Display(Name = "Quando")]
        public DateTime Quando { get; set; }
        [Required]
        [Display(Name = "Onde")]
        public string Onde { get; set; }
        [Display(Name = "Cancelado")]
        public bool Cancelado { get; set; }
        public virtual SindicoViewModel Sindico { get; set; }

        public long[] PresencaSet { get; set; }
        public string Ata { get; set; }
    }
}
