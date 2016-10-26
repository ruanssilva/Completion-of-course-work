using LVSA.Base.Infrastructure.CrossCutting.REST;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace LVSA.Base.Presentation.Rest
{
    public class PasswordRest : AuthRest<dynamic>
    {
        public PasswordRest(string token = null)
            : base("api/Account/ChangePassword", token)
        {

        }

        public string Post()
        {
            HttpWebResponse response = Response(WebRequestMethods.Http.Post, contenttype: URequestContentTypes.ApplicationJson);

            if (response.StatusCode == HttpStatusCode.OK)
                return null;

            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
    }
}