using LVSA.Security.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Application.ViewModels
{
    public class UsuarioGrupoViewModel
    {
        [Required]
        [Display(Name = "Usuário")]
        public long UsuarioId { get; set; }
        [Required]
        [Display(Name = "Grupo")]
        public int GrupoId { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public GrupoViewModel Grupo { get; set; }        
    }
}
