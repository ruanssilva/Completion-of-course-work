using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LVSA.Security.Service.Filters;

namespace LVSA.Security.Service.Controllers
{
    [DesenvolvedorFilterAttribute]
    public class DesenvolvedorController : AutenticaController
    {
    }
}
