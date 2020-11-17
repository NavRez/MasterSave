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
            string connectionString = @"mongodb://sara:rHFncA47vQfBGVYmZgIn6Q0Epc5gbdLvNYPvx6jwSP20cy65D2qQpzMWFgzRIOp1FHTfotmgfkqvgzeETkclZQ==@sara.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@sara@";
            //connectionString is the mongodb address from azure you should put
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            //same for the settings

            CosmosClient = new MongoClient(settings);
            MongoDatabase = CosmosClient.GetDatabase("admin");
            //name of my database
        }

        public void AddJson(JObject jObject)
        {
            BsonDocument bsonElements = BsonDocument.Parse(jObject.ToString());
            MongoCollection.InsertOne(bsonElements);
        }
        public Dictionary<string, BsonValue> RetrieveDict()
        {
            var sample = MongoDatabase.GetCollection<BsonDocument>("sara");
            //name of my collection
            var documents = sample.Find(new BsonDocument()).ToList();
            var dictionary = new Dictionary<string, BsonValue>();

            List<Dictionary<string,BsonValue>> dictList = new List<Dictionary<string, BsonValue>>();

            foreach (BsonDocument bsons in documents)
            {
                var internalDict = new Dictionary<string, BsonValue>();
                Recurse(bsons, internalDict);
                dictList.Add(internalDict);

                if (dictList.Count == 4)
                {
                    var valTest = dictList[3]["readResults"][0]["lines"][0]["text"].RawValue;
                    int i = 1;
                    while (true)
                    {
                        try
                        {
                            var valTest1 = dictList[3]["readResults"][0]["lines"][i++]["text"].RawValue;

                        }
                        catch(Exception e)
                        {
                            break;
                        }
                                            }
                }
            }

            //Console.WriteLine("The list of databases are:");

            //foreach (BsonDocument doc in documents)
            //{
            //    Console.WriteLine(doc.ToString());
            //}
            return (dictionary = dictList.ElementAt<Dictionary<string, BsonValue>>(0));
           
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

        MongoClient CosmosClient { get; set; }
        IMongoDatabase MongoDatabase { get; set; }
        IMongoCollection<BsonDocument> MongoCollection { get; set; }


    }
}