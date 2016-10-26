using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LVSA.Base.Presentation.Rest
{
    public class AuthRest<TEntity> : RestBase<TEntity>
    {
        public string Token
        {
            set
            {
                Headers.Remove("Authorization");
                Headers.Add("Authorization", "Bearer " + value);
            }
        }

        public AuthRest(string uri, string token)
            : base(uri)
        {
            Headers.Add("Authorization", "Bearer " + token);
        }
    }
}