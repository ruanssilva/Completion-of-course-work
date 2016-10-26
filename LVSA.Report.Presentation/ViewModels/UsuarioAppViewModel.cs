using LVSA.Security.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LVSA.Report.Presentation.ViewModels
{
    public class UsuarioAppViewModel : UsuarioViewModel
    {
        public IEnumerable<LVSA.Report.Application.ViewModels.GrupoViewModel> Grupos { get; set; }

        public UsuarioAppViewModel()
        {

        }

        public UsuarioAppViewModel(UsuarioViewModel parent)
        {
            if (parent != null)
            {
                this.Id = parent.Id;
                this.Nome = parent.Nome;
                this.Email = parent.Email;
                this.Bloqueado = parent.Bloqueado;
            }
        }
    }
}