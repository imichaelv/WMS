using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wamasys.Models
{
    /// <summary>
    /// Contains attributes for all Order types.
    /// </summary>
    public class OrderViewModel
    {
        public int Id { get; set; }
    }

    /// <summary>
    /// Contains atributes for orders from suppliers.
    /// </summary>
    public class SupplierOrderViewModel : OrderViewModel
    {
        public int Amount { get; set; }

        public int StatusId { get; set; }
    }
}