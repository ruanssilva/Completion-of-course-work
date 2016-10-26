using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using LVSA.Base.Application.ComponentModel.DataAnnotations;

namespace LVSA.Security.Application.ViewModels
{
    public class TipoUsuarioViewModel
    {
        public short Id { get; set; }
        [ComprimentoMaximo(65)]
        public string Nome { get; set; }
        [ComprimentoMaximo(8)]
        [DisplayName("Código")]
        public string Codigo { get; set; }
        [ComprimentoMaximo(255)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
