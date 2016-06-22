using Wamasys.Models.Api;
using Wamasys.Models.Database;
using System.Linq;
using System.Collections.Generic;

namespace Wamasys.Services
{
    public class SupplierOrdersRepository
    {
        public async void InsertSupplierOrder(SupplierOrderApiModel order)
        {
            using (var db = new ApplicationDbContext())
            {
                var supplierOrder = new SupplierOrder();
                supplierOrder.Amount = order.Amount;
                supplierOrder.ProductId = order.ProductId;
                supplierOrder.StatusId = order.StatusId;
                await db.SaveChangesAsync();
            }
        }

        public List<SupplierOrder> GetCurrentOrders()
        {
            using (var db = new ApplicationDbContext())
            {
                List<SupplierOrder> orders = db.SupplierOrder.Where(row => row.StatusId == 1).ToList();
                return orders;
            }
        }

        //<summary>
        //  This methode should be invoked AFTER the list has been given to the requesting entitiy.
        // This is because if would still be the same objects beeing used.
        //</summary>
        public async void UpdateOrders(List<SupplierOrder> orders, int newStatus)
        {
            using (var db = new ApplicationDbContext())
            {
                foreach(SupplierOrder order in orders)
                {
                    order.StatusId = newStatus;
                }
                await db.SaveChangesAsync();
            }
        }

        public string GetStatus(int SupplierOrderId)
        {
            using (var db = new ApplicationDbContext())
            {
                CustomerOrder customerOrder = db.CustomerOrder.Where(row => row.CustomerOrderid == SupplierOrderId).FirstOrDefault();
                return db.Status.Where(row => row.StatusId == customerOrder.StatusId).FirstOrDefault().Name;
            }
            return "Error";
        }

        public async void AddItems(int amount, int productId)
        {
            using (var db = new ApplicationDbContext())
            {
                List<Item> usedGantrys = db.Item.Where(row => row.GantryId != 0).ToList();
                List<Gantry> gantry = db.Gantry.Where(row => !usedGantrys.Any(row2 => row2.GantryId == row.GantryId)).ToList();
                for (int i = 0; i < amount; i++)
                {
                    Gantry tobeStored = gantry.FirstOrDefault();
                    Item item = new Item();
                    item.ProductId = productId;
                    item.CustomerOrderId = 0;
                    item.GantryId = tobeStored.GantryId;
                    gantry.Remove(tobeStored);
                }
                await db.SaveChangesAsync();
            }
        }
    }
}