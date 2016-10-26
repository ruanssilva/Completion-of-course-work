using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVSA.Base.Application.ComponentModel.DataAnnotations;

namespace LVSA.Security.Application.ViewModels
{
    public class ConexaoViewModel
    {
        public int Id { get; set; }
        [Obrigatorio]
        [ComprimentoMaximo(1)]
        [DisplayName("Código")]
        public string Codigo { get; set; }
        [Obrigatorio]
        [ComprimentoMaximo(65)]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [Obrigatorio]
        [DisplayName("String de conexão")]
        public string ConnectionString { get; set; }
    }
}
