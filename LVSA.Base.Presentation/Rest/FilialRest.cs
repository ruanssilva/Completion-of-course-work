using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Base.Presentation.Rest
{
    public class FilialRest : AuthRest<FilialViewModel>
    {
        public FilialRest(string token = null)
            : base("/api/filial", token)
        {

        }

        public FilialViewModel Get(short id)
        {
            HttpWebResponse response = Response(WebRequestMethods.Http.Get, uri: "/api/filial/" + id);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<FilialViewModel>(new StreamReader(response.GetResponseStream()).ReadToEnd());
            else
                throw new HttpResponseException(response.StatusCode);
        }

        

    }
}