using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace Wamasys.Models.Api
{
    public class DeliveryModel
    {
        public int SupplierId { get; set; }

        public int OrderId { get; set; }
    }
}