using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using XSerializer;
using XSerializer.Encryption;

namespace Wamasys.Models
{
    public class OrderParserModelView
    {
        StringBuilder output = new StringBuilder();
       
        public void recieveOrder(string input)
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(input))) ;
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(output, ws))
                {
                    while()
                    {

                    }
                }
            } 
        }

        public void InsertOrder()
        {

        }
    }
}