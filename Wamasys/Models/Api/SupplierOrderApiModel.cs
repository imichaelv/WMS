using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wamasys.Models.Api
{
    public class SupplierOrderApiModel
    {
        public int SupplierId { get; set; }

        public int StatusId { get; set; }

        public int ProductId { get; set; }

        public int Amount { get; set; }
        

        public DateTime datetime { get; set; }
    }
}