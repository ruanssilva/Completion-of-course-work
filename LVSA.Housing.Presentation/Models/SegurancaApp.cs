using LVSA.Housing.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LVSA.Housing.Presentation.Models
{
    public class SegurancaApp
    {
        public string Id { get; set; }
        public DateTime UltimaAtividade { get; set; }

        public SindicoViewModel Sindico { get; set; }
        public MoradorViewModel Morador { get; set; }
    }
}