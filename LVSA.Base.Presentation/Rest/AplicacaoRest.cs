using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using LVSA.Security.Application.ViewModels;
using System.Web.Http;

namespace LVSA.Base.Presentation.Rest
{
    public class AplicacaoRest : AuthRest<AplicacaoViewModel>
    {
        public AplicacaoRest(string token = null)
            : base("/api/aplicacao", token)
        {

        }

        public AplicacaoViewModel Get(long id)
        {
            HttpWebResponse response = Response(WebRequestMethods.Http.Get, uri: "/api/aplicacao/" + id);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<AplicacaoViewModel>(new StreamReader(response.GetResponseStream()).ReadToEnd());
            else
                throw new HttpResponseException(response.StatusCode);
        }
    }
}