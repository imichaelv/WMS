﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wamasys.Models.Api
{
    public class OrderModel
    {
        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        public string Status { get; set; }

        public ProductModel[] Products { get; set; }

        public DateTime DateTime { get; set; }
    }
}