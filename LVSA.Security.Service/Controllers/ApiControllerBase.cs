using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using LVSA.Base.Infrastructure.Data.DbContexts;
using LVSA.Security.Application.Models;

namespace LVSA.Security.Service.Controllers
{
    public class ApiControllerBase : ApiController
    {
        public static Ambiente Ambiente { get; set; }

        //public ApiControllerBase()
        //{
        //    if ((int)Ambiente == 0)
        //    {
        //        if (WebConfigurationManager.AppSettings["LVSA.Security.Application.Models.Ambiente"] == "Producao")
        //        {
        //            BaseContext.Ambiente = 'P';
        //            Ambiente = Application.Models.Ambiente.Producao;
        //        }
        //        else if (WebConfigurationManager.AppSettings["LVSA.Security.Application.Models.Ambiente"] == "Homologacao")
        //        {
        //            BaseContext.Ambiente = 'H';
        //            Ambiente = Application.Models.Ambiente.Homologacao;
        //        }
        //        else
        //        {
        //            BaseContext.Ambiente = 'D';
        //            Ambiente = Application.Models.Ambiente.Desenvolvimento;
        //        }
        //    }
        //}

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
