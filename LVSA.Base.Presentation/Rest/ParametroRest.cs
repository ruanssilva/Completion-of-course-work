using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace LVSA.Base.Presentation.Rest
{
    public class ParametroRest : AuthRest<dynamic>
    {
        public ParametroRest(string token = null)
            : base("/api/parametro", token)
        {

        }

        public dynamic Get(string id)
        {
            HttpWebResponse response = Response(WebRequestMethods.Http.Get, uri: "/api/parametro/" + id);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<dynamic>(new StreamReader(response.GetResponseStream()).ReadToEnd());
            else
                throw new HttpResponseException(response.StatusCode);
        }

        public void Post(string key, string value)
        {
            HttpWebResponse response = Response(WebRequestMethods.Http.Post, uri: "/api/parametro/key/" + HttpUtility.UrlDecode(key) + "/value/?value=" + HttpUtility.UrlDecode(value));

            if (response.StatusCode != HttpStatusCode.OK)
            {

                string kk = new StreamReader(response.GetResponseStream()).ReadToEnd();
                throw new HttpResponseException(response.StatusCode);
            }
        }

    }
}