using Wamasys.Models.Api;
using Wamasys.Models.Database;

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

        public string GetStatus(int orderId)
        {
            return "Error";
        }
    }
}