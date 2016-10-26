using LVSA.Report.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Report.Presentation.ViewModels
{
    public class InstrucaoAppViewModel : InstrucaoViewModel
    {
        [AllowHtml]
        public string CodeApp { get { return Code; } set { Code = value; } }

        public InstrucaoAppViewModel()
        {

        }

        public InstrucaoAppViewModel(InstrucaoViewModel parent)
        {
            this.Id = parent.Id;
            this.Code = parent.Code;
            this.Codigo = parent.Codigo;
            this.Descricao = parent.Descricao;
            this.Cubos = parent.Cubos;
            this.CategoriaInstrucaoId = parent.CategoriaInstrucaoId;
            this.Ativo = parent.Ativo;
        }
    }
}