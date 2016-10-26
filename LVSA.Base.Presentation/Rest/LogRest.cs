using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LVSA.Base.Presentation.Rest
{
    public class LogRest : AuthRest<dynamic>
    {
        public LogRest(string token = null)
            : base("/api/log", token)
        {
            
        }
    }
}