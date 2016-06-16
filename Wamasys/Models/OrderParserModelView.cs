using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Wamasys.Models
{
    public class OrderParserModelView
    {
        StringBuilder output = new StringBuilder();

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


        public void InsertOrder(MakeOrderModel customerOrder)
        {

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


