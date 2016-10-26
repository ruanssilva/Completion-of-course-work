using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LVSA.Base.Presentation.ViewModels
{
    public class GritterViewModel
    {
        /// <summary>
        /// Título
        /// </summary>
        public string Tittle { get; set; }
        /// <summary>
        /// Mensagem
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Se é centralizado na tela
        /// </summary>
        public bool Center { get; set; }
        /// <summary>
        /// Se é fixo na tela
        /// </summary>
        public bool Sticky { get; set; }
        /// <summary>
        /// Estilo
        /// </summary>
        public GritterStyle Style { get; set; }
    }

    /// <summary>
    /// Numeração dos estilos
    /// </summary>
    public enum GritterStyle {
        Success,
        Error,
        Warning,
        Default,
        Information
    }
}