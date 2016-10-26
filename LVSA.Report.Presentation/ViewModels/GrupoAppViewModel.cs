using LVSA.Report.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LVSA.Report.Presentation.ViewModels
{
    public class GrupoAppViewModel : GrupoViewModel
    {
        [Display(Name="Categoria")]
        public int? CategoriaId { get; set; }
        public List<CategoriaCuboViewModel> Categorias { get; set; }

        public GrupoAppViewModel()
        {

        }

        public GrupoAppViewModel(GrupoViewModel parent)
        {
            if (parent != null)
            {
                this.Id = parent.Id;
                this.Nome = parent.Nome;
                this.Selecionado = parent.Selecionado;
                this.Ativo = parent.Ativo;
                this.Cubos = parent.Cubos;
            }
        }
    }
}