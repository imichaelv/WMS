using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
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

    /// <summary>
    /// Contains the list of products and the attributes for the search query.
    /// </summary>
    public class ProductsViewModel
    {
        public List<Product> Products { get; set; }

        [Display(Name = "Product name")]
        public string Name { get; set; }

        [Display(Name = "Supplier code")]
        public int? SupplierId { get; set; }

        [Display(Name = "Product code")]
        public int? ProductId { get; set; }

        [Display(Name = "Minimum age")]
        public int? Age { get; set; }

        public SelectList Brands { get; set; }

        public string SelectedBrand { get; set; }
    }
}