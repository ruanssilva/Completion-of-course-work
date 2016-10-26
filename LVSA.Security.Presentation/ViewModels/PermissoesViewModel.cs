using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Security.Presentation.ViewModels
{
    public class PermissoesViewModel
    {
        /// <summary>
        /// Grupo
        /// </summary>
        public GrupoViewModel Grupo { get; set; }
        /// <summary>
        /// Aplicação
        /// </summary>
        public AplicacaoViewModel Aplicacao { get; set; }
    }
}