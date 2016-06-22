using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wamasys.Models.Api
{
    public class OrderStatusModel
    {
        public int OrderId { get; set; }

        public string Status { get; set; }
    }
}