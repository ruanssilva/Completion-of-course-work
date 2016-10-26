using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LVSA.Base.Presentation.Rest
{
    public class DLogRest : AuthRest<dynamic>
    {
        public DLogRest(string token)
            : base("/api/dlog", token)
        {

        }
    }
}