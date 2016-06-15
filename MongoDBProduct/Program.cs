using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MongoDBProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoDBConnection connection = new MongoDBConnection();
            connection.createConnection();
            
        }
    }
}
