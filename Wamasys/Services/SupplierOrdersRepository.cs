using Wamasys.Models.Api;
using Wamasys.Models.Database;
using System.Linq;
using System.Collections.Generic;

namespace Wamasys.Services
{
    public class SupplierOrdersRepository
    {
        public async void InsertSupplierOrder(SupplierOrderModel order)
        {
            using (var db = new ApplicationDbContext())
            {
                var supplierOrder = new SupplierOrder();
                supplierOrder.Amount = order.Amount;
                supplierOrder.ProductId = order.ProductId;
                supplierOrder.StatusId = GetStatusId("Nieuwe bestelling");
                await db.SaveChangesAsync();
            }
        }

        public List<SupplierOrder> GetCurrentOrders(int productId)
        {
            using (var db = new ApplicationDbContext())
            {
                List<SupplierOrder> orders = db.SupplierOrder.Where(row => row.StatusId != GetStatusId("Afgeleverd") && row.ProductId == productId).ToList();
                return orders;
            }
        }

        public void SeeIfWeNeedAnyOrdersAndIfSoDoSomethingAboutIt(int productId)
        {
            using (var db = new ApplicationDbContext())
            {
                List<Item> items = db.Item.Where(row => row.ProductId == productId && row.GantryId !=0).ToList();
                List<SupplierOrder> supplierOrders = GetCurrentOrders(productId);
                Product product = db.Product.FirstOrDefault(row => row.ProductId == productId);
                int supply = 0;
                foreach(SupplierOrder order in supplierOrders)
                {
                    supply = supply + order.Amount;
                }
                supply = supply + items.Count;
            }
        }

        private void OrderStuffIfINeedToOrderStuff(int supply, Product product)
        {
            int minimumAmount = product.MinimumAmount;
            bool needToOrderYN= false;
            if(supply < minimumAmount)
            {
                int needToOrder = minimumAmount - supply;
                needToOrderYN = true;
            }
        }
       

        //<summary>
        //  This methode should be invoked AFTER the list has been given to the requesting entitiy.
        // This is because if would still be the same objects beeing used.
        //</summary>
        public async void UpdateOrders(List<SupplierOrder> orders, string newStatus)
        {
            using (var db = new ApplicationDbContext())
            {
                foreach (SupplierOrder order in orders)
                {
                    order.StatusId = GetStatusId(newStatus);
                }
                await db.SaveChangesAsync();
            }
        }

        public string GetStatus(int SupplierOrderId)
        {
            using (var db = new ApplicationDbContext())
            {
                SupplierOrder supplierOrder = db.SupplierOrder.FirstOrDefault(row => row.SupplierOrderId == SupplierOrderId);
                if (supplierOrder != null)
                {
                    if (supplierOrder.Status != null)
                    {
                        return supplierOrder.Status.Name;
                    }
                }
            }
            return "Error";
        }

        public async void ChangeStatus(int supplierOrderId, string newStatus)
        {
            using (var db = new ApplicationDbContext())
            {
                SupplierOrder supplierOrder = db.SupplierOrder.FirstOrDefault(row => row.SupplierOrderId == supplierOrderId);
                Status status = db.Status.FirstOrDefault(row => row.Name == newStatus);
                if(status !=null)
                {
                    supplierOrder.Status = status;
                    supplierOrder.StatusId = status.StatusId;
                }
                await db.SaveChangesAsync();
            }
        }

        public int GetStatusId( string statusName)
        {
            using (var db = new ApplicationDbContext())
            {
                Status status = db.Status.FirstOrDefault(row => row.Name == statusName);
                if(status != null)
                {
                    return status.StatusId;
                }
            }
            return -1;
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