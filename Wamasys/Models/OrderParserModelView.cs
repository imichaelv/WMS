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
            CustomerOrderViewModel customerOrder = new CustomerOrderViewModel();
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
                            customerOrder.CompanyId = int.Parse(reader.Value);
                            break;
                        case "amount":
                            
                            break;
                    }
                }
            }
        }
    }

    public void InsertOrder()
    {

    }
}
}