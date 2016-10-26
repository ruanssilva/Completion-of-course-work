using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LVSA.Security.Service.Controllers
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
            return null;
        }
    }
}