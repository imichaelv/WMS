using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wamasys.Models.Api
{
    public class OrderApiModel
    {
        public int CustomerId { get; set; }

        public int StatusId { get; set; }

        public List<OrderModel> Orders { get; set; }

        public DateTime DateTime { get; set; }
    }
}