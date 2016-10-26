using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Base.Presentation.Controllers
{
    public class ErroController : Controller
    {
        // GET: Erro
        public ActionResult Index(string id = null)
        {
            if (string.IsNullOrWhiteSpace(id))
                return View("Index");

            switch (id)
            {
                case "403":
                    Response.StatusCode = 403; 
                    return View("403");
                case "500":
                default:
                    Response.StatusCode = 500;
                    return View("500");
            }
        }
    }
}