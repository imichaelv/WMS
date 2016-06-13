using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wamasys.Models.Database
{
    public class Supplier
    {

        public Supplier()
        {
            Products = new HashSet<Product>();
            ApplicationUsers = new HashSet<ApplicationUser>();
        }

        [Key]
        public int SupplierId { get; set; }

        public string Name { get; set; }

        public string HouseNumber { get; set; }

        public string City { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

    }
}