using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Wamasys.Models.Mongo
{
    /// <summary>
    /// Contains attributes that are based upon
    /// the document structure of a product in MongoDB.
    /// </summary>
    public class Product
    {
        [BsonId]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<BsonValue> Attributes { get; set; }

        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public int Age { get; set; }

        public List<BsonValue> Tags { get; set; }
    }
}