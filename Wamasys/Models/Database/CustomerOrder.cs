using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wamasys.Models.Database
{
    public class CustomerOrder
    {

        public CustomerOrder()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        public int CustomerOrderid { get; set; }

        public DateTime Date { get; set; }

        public int CompanyId { get; set; }

        public int StatusId { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
    }
}