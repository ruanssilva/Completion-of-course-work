using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Security.Presentation.ViewModels
{
    public class AgrupamentosViewModel
    {
        /// <summary>
        /// Usuário
        /// </summary>
        public UsuarioViewModel Usuario { get; set; }
        /// <summary>
        /// Grupo de usuários
        /// </summary>
        public GrupoViewModel Grupo { get; set; }
        /// <summary>
        /// Coleçao de usuários
        /// </summary>
        public IEnumerable<UsuarioViewModel> UsuarioSet { get; set; }
        /// <summary>
        /// Coleção de grupos
        /// </summary>
        public IEnumerable<GrupoViewModel> GrupoSet { get; set; }
    }
}