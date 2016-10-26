using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using LVSA.Base.Application.Exceptions;
using LVSA.Base.Presentation.Exceptions;
using LVSA.Base.Presentation.ViewModels;

namespace LVSA.Base.Presentation.Controllers
{
    public class ControllerBase : Controller
    {
        public void SetCache<TObject>(TObject obj, string key)
            where TObject : class
        {
            if (obj != null)
                HttpRuntime.Cache[key] = obj;
            else
                HttpRuntime.Cache.Remove(key);
        }

        public TObject GetCache<TObject>(string key)
            where TObject : class
        {
            if (HttpRuntime.Cache[key] != null)
                return (TObject)HttpRuntime.Cache[key];
            return default(TObject);
        }


        public void AddShortcut(string display, string url, string icon = "fa fa-arrow-left")
        {
            _shortcut[display] = new KeyValuePair<string, string>(icon, url);
        }

        private Dictionary<string, KeyValuePair<string, string>> _shortcut
        {
            get
            {
                if (TempData["LVSA.Base.Presentation#Shortcut"] == null)
                    TempData["LVSA.Base.Presentation#Shortcut"] = new Dictionary<string, KeyValuePair<string, string>> { };

                return (Dictionary<string, KeyValuePair<string, string>>)TempData["LVSA.Base.Presentation#Shortcut"];
            }
            set
            {
                TempData["LVSA.Base.Presentation#Shortcut"] = value;
            }
        }

        protected List<GritterViewModel> Gritters
        {
            get
            {
                if (TempData["LVSA.CDN.Plugins.Gritter"] == null)
                    TempData["LVSA.CDN.Plugins.Gritter"] = new List<GritterViewModel> { };

                return (List<GritterViewModel>)TempData["LVSA.CDN.Plugins.Gritter"];
            }
            set
            {
                TempData["LVSA.CDN.Plugins.Gritter"] = value;
            }
        }

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    if (filterContext.ExceptionHandled)
        //        return;

        //    filterContext.Result = RedirectToAction("Index", "Erro", new { id = "500" });

        //    filterContext.ExceptionHandled = true;
        //}

        protected virtual void HandlingException(Exception exception)
        {
            if (exception is NoRecordsFoundException)
            {
                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Registro não encontrado",
                    Message = "O registro selecionado não foi encontrado. Verifique se o mesmo não foi excluído anteriormente. Caso o erro persista contacte o administrador.",
                    Style = GritterStyle.Warning,
                    Sticky = true
                });

                return;
            }

            if (exception is DbEntityValidationException)
            {
                Gritters.Add(new GritterViewModel
                {
                    Tittle = "Ops! Operação inválida",
                    Message = "A base de dados recusou a entrada dos registros informados e esta operação não pode ser concluída.",
                    Style = GritterStyle.Warning,
                    Sticky = true
                });

                return;
            }

            switch (exception.HResult)
            {
                case -2146233087:
                case -2146233079:
                    Gritters.Add(new GritterViewModel
                    {
                        Tittle = "Ops! Operação inválida",
                        Message = "Existe outros registros vinculados e esta operação não pode ser concluída.",
                        Style = GritterStyle.Warning,
                        Sticky = true
                    });
                    break;

                default:
                    Gritters.Add(new GritterViewModel
                    {
                        Tittle = "Ops! Ocorreu um erro",
                        Message = "Desculpe, mas não foi possível processar a operação. Tente novamente mais tarde ou contacte o administrador." + exception.Message,
                        Style = GritterStyle.Error,
                        Sticky = true
                    });
                    break;
            }
        }

        protected virtual string PartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                throw new Exception("É necessário passar a view");

            string result = "";
            object old = ViewData.Model;

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                result = sw.GetStringBuilder().ToString();
            }

            ViewData.Model = old;

            return result;
        }
    }
}