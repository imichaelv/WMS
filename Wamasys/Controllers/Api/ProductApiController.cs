using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Wamasys.Identity;
using Wamasys.Models.Api;
using Wamasys.Models.Database;
using Wamasys.Services;

namespace Wamasys.Controllers
{
    [ApiAuthentication]
    public class ProductApiController : ApiController
    {
        public ProductModel Get()
        {
            return Get(0)[0];
        }

        public ProductModel[] Get(int id)
        {
            using (var repo = new ProductRepository())
            {
                var products = repo.GetProducts(id);

                if (products != null && products.Length < 0)
                {
                    return products;
                }

                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("There are no items on this page"),
                    ReasonPhrase = "The given page number was too high"
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}