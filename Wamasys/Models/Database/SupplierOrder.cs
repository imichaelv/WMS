using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wamasys.Models.Database
{
    public class SupplierOrder
    {

        [Key]
        public int SupplierOrderId { get; set; }

        public int Amount { get; set; }

        public int? StatusId { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

    }
}