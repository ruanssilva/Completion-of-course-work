using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Base.Presentation.Rest
{
    public class ColigadaRest : AuthRest<ColigadaViewModel>
    {
        public ColigadaRest(string token = null)
            : base("/api/coligada", token)
        {

        }

        
    }
}