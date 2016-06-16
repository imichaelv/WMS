using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wamasys.Models.Mongo
{
    /// <summary>
    /// Contains attributes that are based upon
    /// the document structure of a product in MongoDB.
    /// </summary>
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<string> Attributes { get; set; }

        public int SupplierId { get; set; }
    }
}