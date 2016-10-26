using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LVSA.Base.Presentation.ViewModels
{
    public class LoginViewModel
    {
        /// <summary>
        /// Usuário
        /// </summary>
        [Required]
        public string Usuario { get; set; }
        /// <summary>
        /// Senha
        /// </summary>
        [Required]
        public string Senha { get; set; }
    }
}