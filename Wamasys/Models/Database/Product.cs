using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wamasys.Models.Database
{
    public class Product
    {
        public Product()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        public int ProductId { get; set; }

        public int MinimumAmount { get; set; }

        public int PropertyId { get; set; }

        public int SupplierId { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
    }
}