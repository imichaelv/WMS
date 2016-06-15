using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wamasys.Models;

namespace Wamasys.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Displays all the products that are present in the catalogue.
        /// </summary>
        /// <returns></returns>
        public ActionResult Products()
        {
            var model = new ProductsViewModel();
            return View(model);
        }
    }
}