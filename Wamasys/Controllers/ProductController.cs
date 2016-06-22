using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Web.Mvc;
using System.Web.WebPages;
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
            return View("Products");
        }

        /// <summary>
        /// Displays product information and
        /// allows the user to order a certain amount of products.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <returns></returns>
        public async Task<ActionResult> Product(int? id)
        {
            if (!id.HasValue)
            {
                return View("Products");
            }

            var collection = Database.GetCollection<BsonDocument>("products");
            var filter = Builders<BsonDocument>.Filter.Eq("product_id", id);
            var result = await collection.Find(filter).FirstOrDefaultAsync();

            var product = new Product
            {
                Name = result.GetValue("name").ToString(),
                Description = result.GetValue("description").ToString(),
                SupplierId = result.GetValue("supplier_id").ToInt32(),
                Attributes = result.GetValue("attributes").ToBsonDocument().Values.ToList(),
                ProductId = id.Value,
                Age = result.GetValue("age").ToInt32(),
                Tags = result.GetValue("tags").ToBsonDocument().Values.ToList()
            };

            var model = new ProductViewModel
            {
                Product = product,
                PropertyId = id.Value
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

            var result = await collection.Find(filter).Limit(30).ToListAsync();
            foreach (var document in result)
            {
                var product = new Product
                {
                    Name = document.GetValue("name").ToString(),
                    ProductId = document.GetValue("product_id").ToInt32(),
                    SupplierId = document.GetValue("supplier_id").ToInt32(),
                    Tags = document.GetValue("tags").ToBsonDocument().Values.ToList(),
                    Age = document.GetValue("age").ToInt32()
                };
                model.Products.Add(product);
            }

            model.Brands = PopulateBrandList(model);

            return View(model);
        }

        /// <summary>
        /// Searches the entire database and finds items that correspond to the given parameters.
        /// Due to balancing purposes, the maximum amount of returnable results is 30.
        /// </summary>
        /// <param name="model">The given parameters to be used during search.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Products(ProductsViewModel model)
        {
            var collection = Database.GetCollection<BsonDocument>("products");
            var builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter;

            // Such an ugly solution, but it works...
            if (!model.SupplierId.HasValue && model.ProductId.HasValue && model.Age.HasValue)
            {
                filter = builder.Eq("product_id", model.ProductId) & builder.Gt("age", model.Age);
            }
            else if (model.SupplierId.HasValue && !model.ProductId.HasValue && model.Age.HasValue)
            {
                filter = builder.Eq("supplier_id", model.SupplierId) & builder.Gt("age", model.Age);
            }
            else if (model.SupplierId.HasValue && model.ProductId.HasValue && !model.Age.HasValue)
            {
                filter = builder.Eq("supplier_id", model.SupplierId) & builder.Eq("product_id", model.ProductId);
            }
            else if (!model.SupplierId.HasValue && !model.ProductId.HasValue && model.Age.HasValue)
            {
                filter = builder.Gt("age", model.Age);
            }
            else if (!model.SupplierId.HasValue && model.ProductId.HasValue && !model.Age.HasValue)
            {
                filter = builder.Eq("product_id", model.ProductId);
            }
            else if (model.SupplierId.HasValue && !model.ProductId.HasValue && !model.Age.HasValue)
            {
                filter = builder.Eq("supplier_id", model.SupplierId);
            }
            else
            {
                filter = builder.Eq("supplier_id", model.SupplierId) & builder.Eq("product_id", model.ProductId) & builder.Gt("age", model.Age);
            }

            var result = await collection.Find(filter).Limit(30).ToListAsync();

            if (result == null || result.Count == 0)
            {
                // Reset these values so the input boxes are empty again
                model.ProductId = null;
                model.SupplierId = null;
                model.Age = null;
                model.Name = "";
                model.Brands = PopulateBrandList(model);
                return View(model);
            }

            // Reinitialize the fucking list, otherwise problems arise...
            model.Products = new List<Product>();

            foreach (var item in result)
            {
                var product = new Product
                {
                    Name = item.GetValue("name").ToString(),
                    ProductId = item.GetValue("product_id").ToInt32(),
                    SupplierId = item.GetValue("supplier_id").ToInt32(),
                    Tags = item.GetValue("tags").ToBsonDocument().Values.ToList(),
                    Age = item.GetValue("age").ToInt32()
                    //Attributes = item.GetValue("attributes").ToBsonDocument().Values.ToList(),
                    //Description = item.GetValue("description").ToString()
                };
                model.Products.Add(product);
            }

            // Reset these values so the input boxes are empty again
            model.ProductId = null;
            model.SupplierId = null;
            model.Name = "";
            model.Age = null;
            model.Brands = PopulateBrandList(model);
            return View(model);
        }

        private SelectList PopulateBrandList(ProductsViewModel model)
        {
            return new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem { Text = "Lego", Value = "Lego"},
                    new SelectListItem { Text = "Duplo", Value = "Duplo"},
                }, "Value", "Text");
        }
    }
}