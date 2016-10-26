using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Security.Service.Models
{
    public class Log
    {
        public DateTime Horario { get; set; }
        [AllowHtml]
        public string Mensagem { get; set; }
        public LogStyle Style { get; set; }
        public string CODUSUARIO { get; set; }
    }

    public enum LogStyle
    {
        Information = 0,
        Success = 1,
        Error = 2,
        Warning = 3
    }
}