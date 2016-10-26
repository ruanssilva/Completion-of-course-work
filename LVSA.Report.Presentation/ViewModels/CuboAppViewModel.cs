using LVSA.Report.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Report.Presentation.ViewModels
{
    public class CuboAppViewModel : CuboViewModel
    {
        [AllowHtml]        
        public string CodeApp { get { return Instrucao != null ? Instrucao.Code : string.Empty; } set { if (Instrucao != null)Instrucao.Code = value; else Instrucao = new InstrucaoViewModel { Code = value }; } }
        [AllowHtml]
        public string TSQLApp { get { return Consulta != null ? Consulta.TSQL : string.Empty; } set { if (Consulta != null)Consulta.TSQL = value; else Consulta = new ConsultaViewModel { TSQL = value }; } }

        [Display(Name="Acesso")]
        public bool Acesso { get; set; }


        public CuboAppViewModel()
        {

        }

        public CuboAppViewModel(CuboViewModel parent)
        {
            if (parent != null)
            {
                this.Ativo = parent.Ativo;
                this.Acesso = parent.Acesso;
                this.CategoriaCubo = parent.CategoriaCubo;
                this.CategoriaCuboId = parent.CategoriaCuboId;
                this.Codigo = parent.Codigo;
                this.Consulta = parent.Consulta;
                this.ConsultaId = parent.ConsultaId;
                this.Descricao = parent.Descricao;
                this.Icon = parent.Icon;
                this.Id = parent.Id;
                this.Instrucao = parent.Instrucao;
                this.InstrucaoId = parent.InstrucaoId;
                this.Rows = parent.Rows;
                this.ShowResult = parent.ShowResult;
                this.Time = parent.Time;
            }
        }
    }
}