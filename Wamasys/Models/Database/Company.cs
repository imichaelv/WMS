using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wamasys.Models.Database
{
    public class Company
    {

        public Company()
        {
            Orders = new HashSet<CustomerOrder>();
            Users = new HashSet<ApplicationUser>();
        }

        [Key]
        public int CompanyId { get; set; }

        public string Name { get; set; }
        
        public string Street { get; set; }

        public string City { get; set; }

        public string HouseNumber { get; set; }

        public string Director { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

        public virtual ICollection<CustomerOrder> Orders { get; set; }
    }
}