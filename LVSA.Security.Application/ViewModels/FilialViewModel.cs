using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LVSA.Security.Application.ViewModels
{
    public class FilialViewModel
    {
        /// <summary>
        /// Código único da filial
        /// </summary>
        public short Id { get; set; }
        /// <summary>
        /// Nome de exibição da filial
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Coligada que pertence a filial
        /// </summary>
        public ColigadaViewModel Coligada { get; set; }

        public short ColigadaId { get; set; }

        public IEnumerable<AplicacaoViewModel> AplicacaoSet { get; set; }
    }
}
