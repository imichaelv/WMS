using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wamasys.Models.Api;
using Wamasys.Models.Database;
using Wamasys.Services;

namespace Wamasys.Controllers.Api
{
    public class ProducerApiController : ApiController
    {
        // GET: api/Test/5
        public SupplierOrder[] Get(int id)
        {
            using (var repo = new SupplierOrdersRepository())
            {
                var Orders = repo.GetCurrentOrders().Take(5).ToArray();
                repo.InsertSupplierOrders(Orders, id);
                return Orders;
            }
        }

        // POST: api/Test
        public void Post(DeliveryModel model)
        {
            using (var repo = new SupplierOrdersRepository())
            {
                repo.ChangeStatus(model.SupplierId, model.OrderId);
            }
        }
    }
}
