using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using LVSA.Noticia.Application.ViewModels;

namespace LVSA.Base.Presentation.Rest
{
    public class NoticiaRest : AuthRest<NoticiaViewModel>
    {
        public NoticiaRest(string token = null)
            : base("/api/noticia", token)
        {

        }

        public NoticiaViewModel Get(long id)
        {
            HttpWebResponse response = Response(WebRequestMethods.Http.Get, uri: "/api/noticia/" + id);

            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<NoticiaViewModel>(new StreamReader(response.GetResponseStream()).ReadToEnd());
            else
                throw new HttpResponseException(response.StatusCode);
        }
    }
}