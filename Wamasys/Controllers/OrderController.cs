using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                Product = new Product()
            };
            return View(model);
        }
    }
}