using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
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

    /// <summary>
    /// Contains attributes for creating orders for suppliers.
    /// </summary>
    public class CreateSupplierOrderViewModel
    {
        [Required]
        public int Amount { get; set; }

        public Product Product { get; set; }

        /// <summary>
        /// Contains products that are available to order.
        /// </summary>
        [Display(Name = "Product")]
        public SelectList Products { get; set; }

        // Temporary though...
        [Display(Name = "Product code")]
        public int ProductCode { get; set; }
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
        // TODO: further implementation of class
        public DateTime DateTime { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }

    public class OrderSummaryViewModel
    {
        public List<CustomerOrder> CustomerOrders { get; set; }

        public List<SupplierOrder> SupplierOrders { get; set; }
    }

    /// <summary>
    /// This class is developed for Robert.
    /// </summary>
    public class TestViewModel
    {
        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        public DateTime DateTime { get; set; }

        public Product Product { get; set; }

        // If one can pick more products for the same order...
        //public List<Product> Products { get; set; }
    }
}