using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LVSA.Noticia.Application.ViewModels;

namespace LVSA.Noticia.Presentation.ViewModels
{
    public class NoticiaViewModel : LVSA.Noticia.Application.ViewModels.NoticiaViewModel
    {
        public NoticiaViewModel()
        {

        }

        public NoticiaViewModel(LVSA.Noticia.Application.ViewModels.NoticiaViewModel parent)
        {
            if (parent != null)
            {
                this.Id = parent.Id;
                this.Autor = parent.Autor;
                this.ExpiraEm = parent.ExpiraEm;
                this.PublicadoEm = parent.PublicadoEm;
                this.Subtitulo = parent.Subtitulo;
                this.Texto = parent.Texto;
                this.Titulo = parent.Titulo;
                this.AplicacaoIdSet = parent.AplicacaoIdSet;
                this.FilialIdSet = parent.FilialIdSet;
                this.ImagemSet = parent.ImagemSet;
                this.Ativo = parent.Ativo;
                this.Tags = parent.Tags;
            }
        }

        [AllowHtml]
        public string TextoCliente { get { return Texto; } set { Texto = value; } }
        public HttpPostedFileBase[] FileSet { get; set; }
        
    }
}