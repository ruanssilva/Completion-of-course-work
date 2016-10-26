using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LVSA.Security.Service.Controllers
{
    public class DLogController : DesenvolvedorController
    {
        // GET: api/DLog
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Logs.OrderByDescending(d => d.Horario));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/DLog/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DLog
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DLog/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DLog/5
        public void Delete(int id)
        {
        }
    }
}
