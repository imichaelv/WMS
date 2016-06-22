using System;
using Wamasys.Models.Api;
using Wamasys.Models.Database;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http;

namespace Wamasys.Services
{
    public class SupplierOrdersRepository : ApiController
    {
        public async void InsertSupplierOrder(SupplierOrder[] order)
        {
            using (var db = new ApplicationDbContext())
            {
                var supplierOrder = new SupplierOrder
                {
                    Amount = order.Amount,
                    ProductId = order.ProductId,
                    StatusId = order.StatusId
                };
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
                List<Item> items = db.Item.Where(row => row.ProductId == productId).ToList() ;
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
                foreach (var order in orders)
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
                var supplierOrder = db.SupplierOrder.FirstOrDefault(row => row.SupplierOrderId == SupplierOrderId);
                if (supplierOrder?.Status != null)
                    {
                        return supplierOrder.Status.Name;
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
                var status = db.Status.FirstOrDefault(row => row.Name == statusName);
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
                var usedGantrys = db.Item.Where(row => row.GantryId != 0).ToList();
                var gantry = db.Gantry.Where(row => usedGantrys.All(row2 => row2.GantryId != row.GantryId)).ToList();
                for (var i = 0; i < amount; i++)
                {
                    var tobeStored = gantry.FirstOrDefault();
                    var item = new Item
                    {
                        ProductId = productId,
                        CustomerOrderId = 0,
                        GantryId = tobeStored.GantryId
                    };
                    gantry.Remove(tobeStored);
                }
                await db.SaveChangesAsync();
            }
        }

       
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}