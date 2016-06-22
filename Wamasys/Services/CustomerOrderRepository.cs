
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Wamasys.Models.Api;
using Wamasys.Models.Database;

namespace Wamasys.Services
{
    public class CustomerOrderRepository : ApiController
    {

        public async void InsertCustomerOrder(OrderModel model)
        {
            using (var db = new ApplicationDbContext())
            {
                var customerOrder = new CustomerOrder();
                customerOrder.Company.CompanyId = model.CustomerId;
                customerOrder.Date = model.DateTime;
                customerOrder.Status.StatusId = GetStatusId("Nieuwe bestelling");
                await db.SaveChangesAsync();
            }
            using (var db = new ApplicationDbContext())
            {
                UpdateItems(db.CustomerOrder.Max(row => row.CustomerOrderid), model.Orders);
            }
        }

        private async void UpdateItems(int orderId, List<ProductModel> orders)
        {
            using (var db = new ApplicationDbContext())
            {
                foreach (ProductModel order in orders)
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

        public List<CustomerOrder> GetCustomerOrders(int customerId)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.CustomerOrder.Where(row => row.CompanyId == customerId).ToList();
            }
        }

        public CustomerOrder GetCustomerOrder(int orderId)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.CustomerOrder.FirstOrDefault(row => row.CustomerOrderid == orderId);
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
                CustomerOrder customerOrder = db.CustomerOrder.FirstOrDefault(row => row.CustomerOrderid == orderId);
                if (customerOrder != null)
                {
                    if (customerOrder.Status != null)
                    {
                        return customerOrder.Status.Name;
                    }
                }
                return null;
            }
        }

        public async void ChangeStatus(CustomerOrder order, string newStatus)
        {
            using (var db = new ApplicationDbContext())
            {

                Status status = db.Status.FirstOrDefault(row => row.Name == newStatus);
                if (status != null)
                {
                    order.Status = status;
                    order.StatusId = status.StatusId;
                }
                await db.SaveChangesAsync();
            }
        }

        public int GetStatusId(string description)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Status.FirstOrDefault(row => row.Name == description).StatusId;
            }
        }
    }
}
