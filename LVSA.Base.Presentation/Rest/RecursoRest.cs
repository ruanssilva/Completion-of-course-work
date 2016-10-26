using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LVSA.Security.Application.ViewModels;

namespace LVSA.Base.Presentation.Rest
{
    public class RecursoRest : AuthRest<RecursoViewModel>
    {
        public RecursoRest(string token = null)
            : base("/api/recurso", token)
        {

        }
    }
}