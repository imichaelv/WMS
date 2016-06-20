using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using Wamasys.Models.Database;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;

namespace Wamasys.Models
{
    public class OrderParserModelView
    {
        StringBuilder output = new StringBuilder();
        public static int NextOrderId;

        public OrderParserModelView()
        {
            NextOrderId = getNexOrderId();
        }

        private int getNexOrderId()
        {
            return 1;
        }

        /*
        public void recieveOrder(string input)
        {
            MakeOrderModel customerOrder = new MakeOrderModel();
            customerOrder.StatusId = 1;
            XmlReader reader = XmlReader.Create(new StringReader(input));

            XmlWriterSettings ws = new XmlWriterSettings();
            ws.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(output, ws))
            {
                while (reader.Read())
                {
                    switch (reader.Name)
                    {
                        case "custemorId":
                            customerOrder.CustemorId = int.Parse(reader.Value);
                            break;
                        case "productId":
                            break;
                        case "amount":
                            customerOrder.Amount = int.Parse(reader.Value);
                            break;
                        case "pricePerProduct ":
                            customerOrder.pricePerProduct = int.Parse(reader.Value);
                            break;
                    }
                }
            }
        }
        */

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async void InsertOrder(MakeOrderModel model)
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
                    if (item.CustomerOrderId == 0)
                    {
                        item.GantryId = 0;
                        item.CustomerOrderId = customerOrder.CustomerOrderid;
                        stopPoint--;
                        if (stopPoint == 0)
                        {
                            break;
                        }
                    }
                }
                
                await db.SaveChangesAsync();
            }
        }
    }

    /*
    var user = UserManager.FindById(User.Identity.GetUserId());
            using (var db = new BijlesportaalDbContext())
            {
                model.Students =
                    new SelectList(db.Match.Where(row => row.GiverId == user.Id).Select(col => col.Taker).ToList(), "Id",
                        "UserName");
            }
    */

   
}


