using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wamasys.Models.Database;

namespace Wamasys.Models
{
    /// <summary>
    /// Contains atributes for orders from suppliers.
    /// </summary>
    public class SupplierOrderViewModel
    {
        public int Id { get; set; }

        public int StatusId { get; set; }

        public int Amount { get; set; }

        public int ProductId { get; set; }
    }

    public class CreateSupplierOrderViewModel
    {
        // Hier moet spul!
    }

    /// <summary>
    /// Contains atributes for orders from customers.
    /// </summary>
    public class CustomerOrderViewModel
    {
        public int Id { get; set; }

        public int StatusId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }
        
        public int CompanyId { get; set; }
    }

    public class CreateCustomerOrderViewModel
    {
        // Hier moet spul!
    }

    public class CustomerSummaryViewModel
    {
        public List<CustomerOrder> CustomerOrders { get; set; }

        public List<SupplierOrder> SupplierOrders { get; set; }
    }
}