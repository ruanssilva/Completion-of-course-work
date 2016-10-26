using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LVSA.Base.Presentation.Exceptions
{
    public class WSTBCException : Exception
    {
        public WSTBCException(string message)
            : base(message)
        {

        }
    }
}