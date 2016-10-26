using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Security.Presentation.ViewModels
{
    public class RecursosViewModel
    {
        /// <summary>
        /// Aplicação
        /// </summary>
        public AplicacaoViewModel Aplicacao { get; set; }
        /// <summary>
        /// Coleção de recursos
        /// </summary>
        public IEnumerable<RecursoViewModel> RecursoSet { get; set; }
        /// <summary>
        /// Recursos
        /// </summary>
        public RecursoViewModel Recurso { get; set; }
    }
}