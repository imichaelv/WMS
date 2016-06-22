using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wamasys.Identity;
using Wamasys.Models.Api;
using Wamasys.Models.Database;
using Wamasys.Services;

namespace Wamasys.Controllers.api
{
    [RoutePrefix("api/CheckOrder")]
    [ApiAuthentication]
    public class CustomerOrderController : ApiController
    {
        // GET api/<controller>/5
        public OrderModel Get(int id)
        {
            using (var repo = new CustomerOrderRepository())
            {
                var order = repo.GetCustomerOrder(id);
                if (order?.Status == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent($"No order with ID = {id}"),
                        ReasonPhrase = "Order ID Not Found"
                    };
                    throw new HttpResponseException(resp);
                }

                return new OrderModel
                {
                    CustomerId = order.CompanyId,
                    OrderId = order.CustomerOrderid,
                    DateTime = order.Date,
                    Status = order.Status.Name,
                    Products = ConvertProductModel(order.Items)
                };
            }
        }

        // POST api/<controller>
        public void Post(OrderModel model)
        {
            using (var repo = new CustomerOrderRepository())
            {
                repo.InsertCustomerOrder(model);
            }
        }

        private ProductModel[] ConvertProductModel(ICollection<Item> items)
        {
            List<ProductModel> productsList = new List<ProductModel>();

            foreach (var item in items)
            {
                productsList.Add(
                    new ProductModel
                    {
                        ProductId = item.ProductId,
                        Amount = items.Count(row => row.ProductId == item.ProductId)
                    }
                );
            }
            return productsList.ToArray();
        }
    }

    [RoutePrefix("api/OrderStatus")]
    [ApiAuthentication]
    public class OrderStatusController : ApiController
    {

        public OrderStatusModel Get(int id)
        {
            using (var repo = new CustomerOrderRepository())
            {
                var order = repo.GetCustomerOrder(id);
                if (order?.Status != null)
                {
                    return new OrderStatusModel
                    {
                        OrderId = order.CustomerOrderid,
                        Status = order.Status.Name
                    };
                }

                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent($"No product with ID = {id}"),
                    ReasonPhrase = "Product ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
        }

        public bool Post(OrderModel model)
        {
            using (var repo = new CustomerOrderRepository())
            {
                repo.InsertCustomerOrder(model);
            }
            return false;
        }
    }
}