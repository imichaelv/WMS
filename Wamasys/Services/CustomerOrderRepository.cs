using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Wamasys.Controllers
{
    public class CustomerOrderController : ApiController
    {
        public void InsertCustomerOrder(MakeOrderModel model)
        {

        }
    }

    public class MakeOrderModel
    {
        public int CustemorId { get; set; }
        public int StatusId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public double pricePerProduct { get; set; }
        public DateTime datetime { get; set; }

    }
}
