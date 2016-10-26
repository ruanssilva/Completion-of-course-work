using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Global.Application.ViewModels
{
    public class ImagemViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(65)]
        [Display(Name="Nome")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Imagem")]
        public byte[] Valor { get; set; }
        public string ContentType { get; set; }
    }
}
