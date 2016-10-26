using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using LVSA.Security.Application.Models;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Base.Presentation.Rest
{
    public class ContextoRest : AuthRest<Seguranca>
    {
        public ContextoRest(string token)
            : base("/api/contexto", token)
        {

        }

        public Seguranca Get()
        {
            HttpWebResponse response = Response(WebRequestMethods.Http.Get);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<Seguranca>(new StreamReader(response.GetResponseStream()).ReadToEnd());
            else
                throw new HttpResponseException(response.StatusCode);
        }

    }
}