using System;
using Wamasys.Models.Api;
using Wamasys.Models.Database;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web.Http;

namespace Wamasys.Services
{
    public class SupplierOrdersRepository : ApiController
    {
        public async void InsertSupplierOrder(SupplierOrder order)
        {
            using (var db = new ApplicationDbContext())
            {
                db.SupplierOrder.Add(order);
                await db.SaveChangesAsync();
            }
        }

        public List<SupplierOrderModel> GetCurrentOrders(int limit)
        {
            using (var db = new ApplicationDbContext())
            {
                var orders = db.SupplierOrder.Where(row => row.StatusId == GetStatusId("In behandeling")).Take(limit);
                var newOrders = new List<SupplierOrderModel>();

                foreach (var order in orders)
                {
                    var convertedOrder = new SupplierOrderModel
                    {
                        ProductId = order.ProductId,
                        OrderId = order.SupplierOrderId,
                        Amount = order.Amount
                    };
                    newOrders.Add(convertedOrder);
                }
                return newOrders;
            }
        }

        public List<SupplierOrder> GetCurrentOrder(int productId)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.SupplierOrder.Where(row => row.StatusId != GetStatusId("Afgeleverd") && row.ProductId == productId).ToList();
            }
        }

        public void SeeIfWeNeedAnyOrdersAndIfSoDoSomethingAboutIt(int productId)
        {
            using (var db = new ApplicationDbContext())
            {
                var items = db.Item.Where(row => row.ProductId == productId && row.GantryId !=0).ToList();
                var supplierOrders = GetCurrentOrder(productId);
                var product = db.Product.FirstOrDefault(row => row.ProductId == productId);
                var supply = 0;
                foreach (var order in supplierOrders)
                {
                    supply = supply + order.Amount;
                }
                supply = supply + items.Count;
            }
        }

        private void OrderStuffIfINeedToOrderStuff(int supply, Product product)
        {
            var minimumAmount = product.MinimumAmount;
            var needToOrderYn = false;
            var needToOrder = 0;
            if (supply < minimumAmount)
            {
                needToOrder = minimumAmount - supply;
                needToOrderYn = true;
            }
            if (needToOrderYn)
            {
                var supplierOrder = new SupplierOrder
                {
                    Amount = needToOrder,
                    ProductId = product.ProductId,
                    Product = product,
                    Status = new Status(),
                    StatusId = 0
                };
                InsertSupplierOrder(supplierOrder);
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
                var supplierOrder = db.SupplierOrder.FirstOrDefault(row => row.SupplierOrderId == supplierOrderId);
                var status = db.Status.FirstOrDefault(row => row.Name == newStatus);
                if (status != null)
                {
                    supplierOrder.Status = status;
                    supplierOrder.StatusId = status.StatusId;
                }
                await db.SaveChangesAsync();
            }
        }

        public int GetStatusId(string statusName)
        {
            using (var db = new ApplicationDbContext())
            {
                var status = db.Status.FirstOrDefault(row => row.Name == statusName);
                if (status != null)
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
    }
}