using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using Microsoft.Azure.Cosmos;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Security.Authentication;

namespace App1
{
    public class CosmosAccess
    {

        public CosmosAccess()
        {
            ;
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

    }
}