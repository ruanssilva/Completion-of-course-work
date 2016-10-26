using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using LVSA.Base.Presentation.Rest;
using LVSA.Security.Application.Models;

namespace LVSA.Noticia.Presentation.Controllers
{
    internal class HomeController : ControllerBase
    {
        // GET: Home
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}