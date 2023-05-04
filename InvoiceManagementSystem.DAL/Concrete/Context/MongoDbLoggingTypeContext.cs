using InvoiceManagementSystem.Entity.Dtos.ConnectionDtos;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.DAL.Concrete.Context
{
    public class MongoDbLoggingTypeContext
    {
        public MongoDbLoggingTypeContext()
        {
            MongoDbConnectionDto connectionDto = new();
            //Connection for MongoDb
            MongoUrl mongoUrl = new(connectionDto.MongoConnectionString);

            var settings=MongoClientSettings.FromUrl(mongoUrl);
            var client = new MongoClient(settings);

            //Database connection
            var database = client.GetDatabase(connectionDto.LogDb);

            //table(collection) connection
            var collection = database.GetCollection<BsonDocument>(connectionDto.LogDbCollection);

            Database = database;
            Collection = collection;
        }
        public IMongoDatabase Database { get; set; }
        public IMongoCollection<BsonDocument> Collection { get; set; }
    }
}
