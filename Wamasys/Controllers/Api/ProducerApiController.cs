using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wamasys.Services;

namespace Wamasys.Controllers.Api
{
    public class ProducerApiController : ApiController
    {
        // GET: api/Test/5
        public string Get(int id)
        {
            using (var repo = new SupplierOrdersRepository())
            {
                return "";
            }
            return "";
        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }
    }
}
