using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wamasys.Models.Database
{
    public class Item
    {

        [Key]
        public int ItemId { get; set; }

        public int ProductId { get; set; }

        public int? GantryId { get; set; }

        public int? CustomerOrderId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("GantryId")]
        public virtual Gantry Gantry { get; set; }

        [ForeignKey("CustomerOrderId")]
        public virtual CustomerOrder CustomerOrder { get; set; }

    }
}