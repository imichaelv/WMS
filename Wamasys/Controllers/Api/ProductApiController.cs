using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Wamasys.Identity;
using Wamasys.Models.Database;

namespace Wamasys.Controllers.Api
{
    [RoutePrefix("api/Product")]
    [ApiAuthentication]
    public class ProductApiController : ApiController
    {
        public Product Get()
        {
            return Get(0)[0];
        }

        public Product[] Get(int id)
        {
            
        }
    }
}