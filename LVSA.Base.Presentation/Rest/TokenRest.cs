using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using LVSA.Base.Infrastructure.CrossCutting.REST;

namespace LVSA.Base.Presentation.Rest
{
    public class TokenRest : RestBase<dynamic>
    {
        public TokenRest()
            : base("/token")
        {

        }

        public object Post()
        {
            HttpWebResponse response = Response(WebRequestMethods.Http.Post, contenttype: URequestContentTypes.XwwwFormUrlEncoded);
            return JsonConvert.DeserializeObject<dynamic>(new StreamReader(response.GetResponseStream()).ReadToEnd());
        }
    }
}