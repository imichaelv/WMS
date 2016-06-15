using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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