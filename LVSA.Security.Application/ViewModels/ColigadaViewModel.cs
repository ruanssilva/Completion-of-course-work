using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LVSA.Security.Application.ViewModels
{
    public class ColigadaViewModel
    {
        /// <summary>
        /// Código único da coligada
        /// </summary>
        [DisplayName("Cod. Coligada")]
        public short Id { get; set; }
        /// <summary>
        /// Nome de exibição da coligada
        /// </summary>
        public string Nome { get; set; }
    }
}
