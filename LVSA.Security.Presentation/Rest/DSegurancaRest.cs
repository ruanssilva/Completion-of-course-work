using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using LVSA.Base.Presentation.Rest;
using System.Web.Http;

namespace LVSA.Security.Presentation.Rest
{
    public class DSegurancaRest : AuthRest<dynamic>
    {
        public DSegurancaRest(string token)
            : base("/api/dseguranca", token)
        {

        }

        public dynamic Get(long id)
        {
            HttpWebResponse response = Response(WebRequestMethods.Http.Get, uri: "/api/dseguranca/" + id);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<dynamic>(new StreamReader(response.GetResponseStream()).ReadToEnd());
            else
                throw new HttpResponseException(response.StatusCode);
        }
    }
}