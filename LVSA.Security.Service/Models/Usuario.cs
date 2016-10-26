using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LVSA.Security.Service.Models
{
    public class Usuario
    {
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}