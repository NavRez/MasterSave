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
using Newtonsoft.Json.Linq;

namespace App1
{
    public class CosmosAccess
    {

        public CosmosAccess()
        {
            ;
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

        MongoClient CosmosClient { get; set; }
        IMongoDatabase MongoDatabase { get; set; }
        IMongoCollection<BsonDocument> MongoCollection { get; set; }

        public static Dictionary<string, BsonValue> RetrieveDict()
        {
            string connectionString = @"mongodb://sara:rHFncA47vQfBGVYmZgIn6Q0Epc5gbdLvNYPvx6jwSP20cy65D2qQpzMWFgzRIOp1FHTfotmgfkqvgzeETkclZQ==@sara.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@sara@";
            //connectionString is the mongodb address from azure you should put
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            //same for the settings

            var mongoClient = new MongoClient(settings);
            IMongoDatabase db = mongoClient.GetDatabase("admin");
            //name of my database

            var sample = db.GetCollection<BsonDocument>("sara");
            //name of my collection
            var documents = sample.Find(new BsonDocument()).FirstOrDefault();
            var dictionary = new Dictionary<string, BsonValue>();

            Recurse(documents, dictionary);

            Console.WriteLine("The list of databases are:");

            //foreach (BsonDocument doc in documents)
            //{
            //    Console.WriteLine(doc.ToString());
            //}
            return dictionary;
           
        }


        //https://stackoverflow.com/questions/39024541/how-to-convert-mongo-document-into-key-value-pair-in-net

        private static void Recurse(BsonDocument doc, Dictionary<string, BsonValue> dictionary)
        {
            foreach (var elm in doc.Elements)
            {
                if (!elm.Value.IsBsonDocument)
                {
                    if (!dictionary.ContainsKey(elm.Name))
                    {
                        dictionary.Add(elm.Name, elm.Value);
                    }
                }
                else
                {
                    Recurse((elm.Value as BsonDocument), dictionary);
                }
            }
        }



    }
}