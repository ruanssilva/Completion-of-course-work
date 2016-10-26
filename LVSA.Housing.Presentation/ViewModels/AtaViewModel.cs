using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Housing.Presentation.ViewModels
{
    public class AtaViewModel
    {
        [AllowHtml]
        public string AtaCliente { get; set; }
    }
}