using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Base.Application.Exceptions
{
    public class NoRecordsFoundException : Exception
    {
        public NoRecordsFoundException(string message)
            : base(message)
        {

        }
    }
}
