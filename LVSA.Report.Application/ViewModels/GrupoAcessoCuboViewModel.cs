using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Report.Application.ViewModels
{
    public class GrupoAcessoCuboViewModel
    {
        [Display(Name = "Grupo")]
        public int GrupoId { get; set; }
        [Display(Name = "Cubo")]
        public int CuboId { get; set; }
        public virtual GrupoViewModel Grupo { get; set; }
        public virtual CuboViewModel Cubo { get; set; }
    }
}
