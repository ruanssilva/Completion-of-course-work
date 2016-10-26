using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Noticia.Application.ViewModels
{
    public class ImagemViewModel
    {
        public long Id { get; set; }
        public byte[] Valor { get; set; }
        public string ContentType { get; set; }
    }
}
