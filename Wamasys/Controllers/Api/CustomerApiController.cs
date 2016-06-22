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
    [RoutePrefix("api/Order")]
    [ApiAuthentication]
    public class CustomerApiController : ApiController
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
                if (!repo.InsertCustomerOrder(model))
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Your order could not be processed"),
                        ReasonPhrase = "Product ID Not Found"
                    };
                    throw new HttpResponseException(resp);
                }
            }
        }

        private ProductModel[] ConvertProductModel(ICollection<Item> items)
        {
            var productsList = new List<ProductModel>();

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

        public void Post(StatusAdjustModel model)
        {
            using (var repo = new CustomerOrderRepository())
            {
                if (!repo.ChangeStatus(repo.GetCustomerOrder(model.OrderId), "Afgeleverd"))
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Could not adjust order status"),
                        ReasonPhrase = "The order does not exist"
                    };
                    throw new HttpResponseException(resp);
                }
            }
        }
    }
}