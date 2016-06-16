using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using Wamasys.Models.Database;

namespace Wamasys.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Minimum amount")]
        public int MinimumAmount { get; set; }

        public int PropertyId { get; set; }
    }

    public class ProductsViewModel
    {
        public List<Mongo.Product> Products { get; set; }

        // Dump tester
        public List<BsonElement> Dump { get; set; }

        public List<BsonValue> Test { get; set; }
    }
}