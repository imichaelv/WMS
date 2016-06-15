using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBProduct
{
    class MongoDBConnection
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected static IMongoCollection<BsonDocument> collection;
        protected DocumentCreator creator;

        public void createConnection()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("wamasys");
            collection = _database.GetCollection<BsonDocument>("products");
            creator = new DocumentCreator();
            CreatingLoop(100000);
        }
        
        public void CreatingLoop(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                System.Threading.Thread.Sleep(5);
                BsonDocument bsonDocument = creator.getDocument(i);
                collection.InsertOneAsync(bsonDocument);
                Console.WriteLine("Creating: " + i);
            }
        }
    }
    
}
