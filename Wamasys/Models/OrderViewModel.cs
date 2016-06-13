using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
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

    // Zeer conceptueel!
    public class CreateSupplierOrderViewModel
    {
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
    }
}