using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using Wamasys.Models.Database;

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

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async void InsertOrder(MakeOrderModel model)
        {
            List<Item> items = new List<Item>();
            var customerOrder = new CustomerOrder();

            customerOrder.CustomerOrderid = NextOrderId;
            NextOrderId++;
            customerOrder.Company.CompanyId = model.CustemorId;
            customerOrder.Date = model.datetime;
            customerOrder.Status.StatusId = model.StatusId;
            int stopPoint = model.Amount;
            foreach(Item item in items)
            {
                if(item.CustomerOrderId == 0)
                {
                    item.GantryId = 0;
                    item.CustomerOrderId = customerOrder.CustomerOrderid;
                    stopPoint--;
                    if(stopPoint == 0)
                    {
                        break;
                    }
                }
            }
        }
    }

    public class MakeOrderModel
    {
        public int CustemorId { get; set; }
        public int StatusId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public double pricePerProduct { get; set; }
        public DateTime datetime { get; set; }

    }
}


