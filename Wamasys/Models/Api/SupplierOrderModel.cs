using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wamasys.Models.Api
{
    public class SupplierOrderModel
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Amount { get; set; }
    }
}