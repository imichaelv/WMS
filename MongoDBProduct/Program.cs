using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MongoDBProduct
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var connection = new MongoDBConnection();
            connection.createConnection();
            
        }
    }
}
