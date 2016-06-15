using System.Collections.Generic;
using System.Web.Mvc;
using Wamasys.Models;
using Wamasys.Models.Database;

namespace Wamasys.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Orders()
        {
            var model = new OrderSummaryViewModel
            {
                SupplierOrders = new List<SupplierOrder>(),
                CustomerOrders = new List<CustomerOrder>()
            };
            return View(model);
        }

        public ActionResult AddCustomerOrder()
        {
            var model = new CreateCustomerOrderViewModel();
            return View(model);
        }

        public ActionResult AddSupplierOrder()
        {
            var model = new CreateSupplierOrderViewModel
            {
                Amount = 0,
                Product = new Product(),
                Products = new List<Product>()
            };

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
                model.Products.Add(product);
                index++;
            }
            return View(model);
        }
    }
}