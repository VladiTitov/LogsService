using System;
using LogsService.Common.Configs.Interfaces;
using LogsService.Common.Models;
using MongoDB.Driver;

namespace LogsService.DataAccess.Mongo.Context
{
    public class MongoContext : IMongoContext, IDisposable
    {
        public IMongoDatabase Database { get; set; }
        public IMongoCollection<LogModel> Collection { get; set; }

        public MongoContext(IMongoDatabaseConfiguration mongoDatabaseConfiguration)
        {
            var client = new MongoClient(mongoDatabaseConfiguration.ConnectionString);

            Database = client.GetDatabase(mongoDatabaseConfiguration.DataBaseName);
            Collection = Database.GetCollection<LogModel>(mongoDatabaseConfiguration.CollectionName);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
