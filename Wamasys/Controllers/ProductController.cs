using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Wamasys.Models;
using Product = Wamasys.Models.Mongo.Product;

namespace Wamasys.Controllers
{
    public class ProductController : Controller
    {
        protected static IMongoClient Client;
        protected static IMongoDatabase Database;

        public ProductController()
        {
            Client = new MongoClient();
            Database = Client.GetDatabase("wamasys");
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Product(int? productId)
        {
            if (!productId.HasValue)
            {
                return View("Products");
            }

            var collection = Database.GetCollection<BsonDocument>("products");
            var filter = Builders<BsonDocument>.Filter.Eq("product_id", productId);
            var result = await collection.Find(filter).FirstOrDefaultAsync();

            var attributes = result.GetValue("attributes").ToBsonDocument();

            var product = new Product
            {
                Name = result.GetValue("name").ToString(),
                Description = result.GetValue("description").ToString(),
                SupplierId = result.GetValue("supplier_id").ToInt32(),
                Attributes = new List<BsonValue>(),
                ProductId = productId.Value
            };

            var model = new ProductViewModel
            {
                Product = product,
                PropertyId = productId.Value
            };


            return View(model);
        }

        /// <summary>
        /// Displays all the products that are present in the catalogue.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Products()
        {
            var model = new ProductsViewModel { Products = new List<Product>() };
            var collection = Database.GetCollection<BsonDocument>("products");
            var filter = new BsonDocument();

            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    // Batch contains a random amount of products...
                    var batch = cursor.Current;
                    // Limit the amount of products per batch...
                    batch = batch.Take(20);
                    foreach (var document in batch)
                    {
                        var product = new Product
                        {
                            Name = document.GetValue("name").ToString(),
                            ProductId = document.GetValue("product_id").ToInt32(),
                            SupplierId = document.GetValue("supplier_id").ToInt32()
                        };
                        model.Products.Add(product);
                    }
                }
            }
            return View(model);
        }
    }
}