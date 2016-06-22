using System;
using System.Text;
using System.Web.Mvc;

namespace Wamasys.Services
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


