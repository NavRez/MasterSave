using System;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Security.Authentication;
using Newtonsoft.Json.Linq;

namespace App1
{
    public class CosmosAccess
    {

        public CosmosAccess()
        {
            string connectionString =
                @"test your input here";
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            CosmosClient = new MongoClient(settings);
            MongoDatabase = CosmosClient.GetDatabase("admin");
            MongoCollection = MongoDatabase.GetCollection<BsonDocument>("ComputerVisionPictures");
        }
        public void AddJson(JObject jObject)
        {
            BsonDocument bsonElements = BsonDocument.Parse(jObject.ToString());
            MongoCollection.InsertOne(bsonElements);
        }
        public class Entity
        {
            public ObjectId _id { get; set; }
            public string Name { get; set; }
        }
        public static string Test()
        {
            string connectionString =
            @"insert your thing";
           MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            var mongoClient = new MongoClient(settings);
            var dbList = mongoClient.ListDatabases();
            IMongoDatabase db = mongoClient.GetDatabase("admin");

            var collList = db.ListCollections().ToList();
            Console.WriteLine("The list of collections are :");

            var collection = db.GetCollection<Entity>("entities");

            var entity = new Entity { Name = "Tom" };
            collection.InsertOneAsync(entity);
            var id = entity._id;

            return "";
        }

        MongoClient CosmosClient { get; set; }
        IMongoDatabase MongoDatabase { get; set; }
        IMongoCollection<BsonDocument> MongoCollection { get; set; }


    }
}