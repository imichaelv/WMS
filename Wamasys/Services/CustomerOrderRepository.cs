
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Wamasys.Models.Api;
using Wamasys.Models.Database;

namespace Wamasys.Services
{
    public class CustomerOrderRepository : ApiController
    {

        public async Task<bool> InsertCustomerOrder(OrderModel model)
        {
            using (var db = new ApplicationDbContext())
            {
                var customerOrder = new CustomerOrder();
                customerOrder.CustomerOrderid = db.CustomerOrder.Max(row => row.CustomerOrderid) + 1;
                customerOrder.Company.CompanyId = model.CustomerId;
                customerOrder.Date = model.DateTime;
                customerOrder.Status.StatusId = GetStatusId("Nieuwe bestelling");
                var succes = await UpdateItems(customerOrder, model.Products.ToList(), db);
                if (succes)
                {
                    await db.SaveChangesAsync();
                }
                return succes;
            }
        }

        private async Task<bool> UpdateItems(CustomerOrder customerOrder, List<ProductModel> orders, ApplicationDbContext db)
        {
            using (db)
            {
                foreach (var order in orders)
                {
                    var items = new List<Item>();
                    items = db.Item.Where(row => row.CustomerOrderId == 0 && row.ProductId == order.ProductId).Take(order.Amount).ToList();
                    if(order.Amount < items.Count)
                    {
                        return false;
                    }
                    foreach (Item item in items)
                    {
                        item.GantryId = 0;
                        item.CustomerOrderId = customerOrder.CustomerOrderid;
                        item.CustomerOrder = customerOrder;
                    }
                }
                await db.SaveChangesAsync();
            }
            return true;
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
                var customerOrder = db.CustomerOrder.FirstOrDefault(row => row.CustomerOrderid == orderId);
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

        public async Task<bool> ChangeStatus(CustomerOrder order, string newStatus)
        {
            using (var db = new ApplicationDbContext())
            {

                var status = db.Status.FirstOrDefault(row => row.Name == newStatus);
                if (status != null)
                {
                    order.Status = status;
                    order.StatusId = status.StatusId;
                }
                await db.SaveChangesAsync();
            }
            return true;
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
