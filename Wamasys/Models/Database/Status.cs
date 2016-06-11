using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wamasys.Models.Database
{
    public class Status
    {
        public Status()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
            SupplierOrders = new HashSet<SupplierOrder>();
        }

        [Key]
        public int StatusId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }

        public virtual ICollection<SupplierOrder> SupplierOrders { get; set; }

    }
}