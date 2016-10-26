using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LVSA.Base.Presentation.Hub
{
    public class UserIdProvider : IUserIdProvider 
    {
        public string GetUserId(IRequest request)
        {
            return "__x__";
        }
    }
}