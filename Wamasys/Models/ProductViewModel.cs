using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wamasys.Models.Mongo;

namespace Wamasys.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Minimum amount")]
        public int MinimumAmount { get; set; }

        public int PropertyId { get; set; }

        public Product Product { get; set; }
    }

    public class ProductsViewModel
    {
        public List<Mongo.Product> Products { get; set; }
    }
}