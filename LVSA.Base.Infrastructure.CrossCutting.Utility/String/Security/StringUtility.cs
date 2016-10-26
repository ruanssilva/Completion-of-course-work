using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVSA.Base.Infrastructure.CrossCutting.Utility.String.Security
{
    public static class StringUtility
    {
        public static string RemoveTagHtml(this string input)
        {
            if (input != null)
                return input.Replace("<", "&lt;")
                            .Replace(">", "&gt;");

            return string.Empty;
        }
    }
}
