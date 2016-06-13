using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using XSerializer;

namespace Wamasys.Models
{
    public class OrderParserModelView
    {   
        public void recieveOrder(XmlDocument xmlfile)
        {
            XSerializerXmlReader Parser = new XSerializerXmlReader();
        }

        public void InsertOrder()
        {

        }
    }
}