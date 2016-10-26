using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Security.Presentation.ViewModels
{
    public class ConcessoesViewModel
    {
        /// <summary>
        /// Coleção de aplicações
        /// </summary>
        public IEnumerable<AplicacaoViewModel> AplicacaoSet { get; set; }
    }
}