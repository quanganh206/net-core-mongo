using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace testmongo.Models
{
    public class DataAccess
    {
        MongoClient _client;
        IMongoDatabase _db;

        public DataAccess()
        {
            var connectionString = "mongodb://localhost/EmployeeDB";
            var mongoUrl = MongoUrl.Create(connectionString);

            _client = new MongoClient(connectionString);
            _db = new MongoClient(mongoUrl).GetDatabase(mongoUrl.DatabaseName);
        }

        public IEnumerable<Product> GetProducts()
        {
            var collection = _db.GetCollection<BsonDocument>("Products");
            List<Product> products = null;
            var filter = new BsonDocument();
            using (var cursor = collection.FindAsync(filter).Result)
            {
                products = new List<Product>();
                while (cursor.MoveNextAsync().Result)
                    {
                        var batch = cursor.Current;
                        foreach (var document in batch)
                        {
                            int id = 0;
                            int.TryParse(document["ProductId"].ToString(), out id);
                            products.Add(new Product()
                            {
                                Id = document["_id"].AsObjectId,
                                ProductId = id,
                                ProductName = document["ProductName"].ToString(),
                                Price = document["Price"].ToInt32(),
                                Category = document["Category"].ToString()
                            });
                        }
                    }
            }
            return products; 
        }
    }
}