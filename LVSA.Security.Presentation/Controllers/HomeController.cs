using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using LVSA.Base.Infrastructure.CrossCutting.REST;
using System.Web.Configuration;
using LVSA.Security.Presentation.Rest;
using LVSA.Security.Application.Models;
using LVSA.Base.Presentation.Hub;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;
using System.Collections.Generic;

namespace LVSA.Security.Presentation.Controllers
{
    internal class HomeController : ControllerBase
    {
        public virtual ActionResult Index(string id = null)
        {
            return View("Index");
        }
    }
}