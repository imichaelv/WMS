using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Wamasys.Models.Api;
using Wamasys.Models.Database;

namespace Wamasys.Services
{
    public class ProductRepository : ApiController
    {

        public ProductModel[] GetProducts(int amount)
        {
            amount = (amount+10)*10;
            var newProductsList = new List<ProductModel>();
            using (var db = new ApplicationDbContext())
            {
                var products = db.Product.Skip(amount - 10).Take(10);
                foreach (var product in products)
                {
                    var newProduct = new ProductModel
                    {
                        ProductId = product.ProductId,
                        Amount = product.MinimumAmount
                    };
                    newProductsList.Add(newProduct);
                }
            }
            return newProductsList.ToArray();
        }

    }
}