using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Wamasys.Models;
using Wamasys.Models.Database;

namespace Wamasys.Controllers
{
    public class OrderController : Controller
    {
        protected static IMongoClient Client;
        protected static IMongoDatabase Database;

        public OrderController()
        {
            Client = new MongoClient();
            Database = Client.GetDatabase("wamasys");
        }

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        /*
        public async Task<ActionResult> Order(int? productId)
        {
            var collection = Database.GetCollection<BsonDocument>("products");
            var result = await collection.FindAsync(Builders<BsonDocument>.Filter.Eq("product_id", productId.ToString()));
            var document = result.FirstOrDefaultAsync().Result;

            var model = new Models.Mongo.Product
            {
                Name = document.GetValue("name").ToString(),
                ProductId = document.GetValue("product_id").ToInt32(),
                SupplierId = document.GetValue("supplier_id").ToInt32(),
                Description = document.GetValue("description").ToString(),
                Attributes = document.AsBsonDocument
            };

            return View(model);
        }
        */

        public ActionResult Orders()
        {
            var model = new OrderSummaryViewModel
            {
                SupplierOrders = new List<SupplierOrder>(),
                CustomerOrders = new List<CustomerOrder>()
            };

            // TODO: filling lists with data.

            return View(model);
        }

        public ActionResult AddCustomerOrder()
        {
            var model = new CreateCustomerOrderViewModel();
            return View(model);
        }

        public ActionResult AddSupplierOrder()
        {
            var model = new CreateSupplierOrderViewModel();
            PopulateProductList(model);
            return View(model);
        }

        /// <summary>
        /// Inserts the supplier order into the database.
        /// </summary>
        /// <param name="model">Contains the information about the order that should be inserted into the database.</param>
        /// <param name="productId">Contains the product ID of the product that should be ordered.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddSupplierOrder(CreateSupplierOrderViewModel model, int? productId)
        {
            if (!ModelState.IsValid || !productId.HasValue)
            {
                PopulateProductList(model);
                ModelState.AddModelError("", "Something went wrong! Please check the fields you (have not) filled in.");
                return View(model);
            }

            // TODO: implementation of inserting supplier orders into the database.

            return View();
        }

        public void PopulateProductList(CreateSupplierOrderViewModel model)
        {
            var list = new List<Product>();

            // Onderstaande is om dummydata te genereren...
            var index = 0;
            while (index < 10)
            {
                var product = new Product
                {
                    ProductId = index,
                    MinimumAmount = index + 50,
                    PropertyId = 2,
                    SupplierId = 2,
                };
                list.Add(product);
                index++;
            }

            model.Products = new SelectList(list, "ProductId", "ProductId");
        }
    }
}