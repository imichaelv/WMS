using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Web.Mvc;
using MongoDB.Driver;
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
                    batch = batch.Take(4);
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