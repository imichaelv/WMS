using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wamasys.Models.Api;

namespace Wamasys.Controllers.api
{
    public class CustomerOrderController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post(OrderApiModel model)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, OrderApiModel model)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}