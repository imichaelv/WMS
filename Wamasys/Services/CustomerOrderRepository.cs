using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Wamasys.Models;
using Wamasys.Models.Api;
using Wamasys.Models.Database;

namespace Wamasys.Controllers
{
    public class CustomerOrderController : ApiController
    {

        public async void InsertCustomerOrder(OrderApiModel model)
        {
            using (var db = new ApplicationDbContext())
            {
                var customerOrder = new CustomerOrder();
                customerOrder.Company.CompanyId = model.CustomerId;
                customerOrder.Date = model.DateTime;
                customerOrder.Status.StatusId = model.StatusId;
                await db.SaveChangesAsync();
            }
            using (var db = new ApplicationDbContext())
            {
                UpdateItems(db.CustomerOrder.Max(row => row.CustomerOrderid), model.Orders);
            }
        }

        private async void UpdateItems(int orderId, List<OrderModel> orders)
        {
            using (var db = new ApplicationDbContext())
            {
                foreach (OrderModel order in orders)
                {
                    List<Item> items = new List<Item>();
                    items = db.Item.Where(row => row.CustomerOrderId == 0 && row.ProductId == order.ProductId).Take(order.Amount).ToList();
                    foreach (Item item in items)
                    {
                        item.GantryId = 0;
                        item.CustomerOrderId = orderId;
                    }
                }
                await db.SaveChangesAsync();
            }
        }

        public List<CustomerOrder> GetCustomerOrder(int customerId)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.CustomerOrder.Where(row => row.CompanyId == customerId).ToList();
            }
        }

        public Item GetItem(int itemId)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Item.FirstOrDefault(row => row.ItemId == itemId);
            }
        }

        public string GetStatus(int orderId)
        {
            using (var db = new ApplicationDbContext())
            {
                CustomerOrder customerOrder = db.CustomerOrder.Where(row => row.CustomerOrderid == orderId).FirstOrDefault();
                return db.Status.Where(row => row.StatusId == customerOrder.StatusId).FirstOrDefault().Name;
            }
        }
    }
}
