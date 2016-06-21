using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wamasys.Models.Api
{
    public class OrderModel
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public double PricePerProduct { get; set; }
    }
}