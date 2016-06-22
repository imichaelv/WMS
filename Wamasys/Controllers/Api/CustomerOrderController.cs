using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Wamasys.Identity;
using Wamasys.Models.Api;
using Wamasys.Models.Database;
using Wamasys.Services;

namespace Wamasys.Controllers.api
{
    [RoutePrefix("api/checkOrder")]
    [ApiAuthentication]
    public class CustomerOrderController : ApiController
    {
/*        // GET api/<controller>
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }*/

        // GET api/<controller>/5
        public CustomerOrder Get(int id)
        {
            using (var repo = new CustomerOrderRepository())
            {
                return repo.GetCustomerOrder(id);
            }
        }

        // POST api/<controller>
        public bool Post(OrderApiModel model)
        {
            using (var repo = new CustomerOrderRepository())
            {
                repo.InsertCustomerOrder(model);
            }
            return false;
        }

        // PUT api/<controller>/5
/*        public void Put(int id, OrderApiModel model)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }*/
    }
}