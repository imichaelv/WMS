﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wamasys.Identity;
using Wamasys.Models.Api;
using Wamasys.Models.Database;
using Wamasys.Services;

namespace Wamasys.Controllers.Api
{
    [RoutePrefix("api/Supplier")]
    [ApiAuthentication]
    public class ProducerApiController : ApiController
    {
        // GET: api/Test/5
        public SupplierOrderModel[] Get(int id)
        {
            using (var repo = new SupplierOrdersRepository())
            {
                var orders = repo.GetCurrentOrders(5);

                foreach (var order in orders)
                {
                    repo.ChangeStatus(order.OrderId, "In behandeling");    
                }
                return orders.ToArray();
            }
        }

        // POST: api/Test
        public void Post(DeliveryModel model)
        {
            using (var repo = new SupplierOrdersRepository())
            {
                repo.ChangeStatus(model.OrderId, "Afgeleverd");
            }
        }
    }
}
