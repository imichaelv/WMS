using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Wamasys.Models.Database;

namespace Wamasys.Controllers
{
    public class CustomerOrderController : ApiController
    {
        public int NextOrderId;

        public int getNextOrderId()
        {
            return 1;
        }

        public async void InsertCustomerOrder(MakeOrderModel model)
        {
            using (var db = new ApplicationDbContext())
            {
                List<Item> items = new List<Item>();

                items = db.Item.Where(row => row.CustomerOrderId == 0).ToList();
                var customerOrder = new CustomerOrder();


                customerOrder.CustomerOrderid = NextOrderId;
                NextOrderId++;
                customerOrder.Company.CompanyId = model.CustemorId;
                customerOrder.Date = model.datetime;
                customerOrder.Status.StatusId = model.StatusId;
                int stopPoint = model.Amount;
                foreach (Item item in items)
                {
                    
                        item.GantryId = 0;
                        item.CustomerOrderId = customerOrder.CustomerOrderid;
                        stopPoint--;
                        if (stopPoint == 0)
                        {
                            break;
                        }
                    
                }

                await db.SaveChangesAsync();
            }
        }
    }
}
