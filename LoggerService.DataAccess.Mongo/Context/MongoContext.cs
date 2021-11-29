using System;
using LogsService.Common.Configs;
using LogsService.Common.Models;
using MongoDB.Driver;

namespace LogsService.DataAccess.Mongo.Context
{
    public class MongoContext : IMongoContext, IDisposable
    {
        public IMongoDatabase Database { get; set; }
        public IMongoCollection<LogModel> Collection { get; set; }

        public MongoContext(Settings settings)
        {
            var client = new MongoClient(settings.ConnectionString);

            Database = client.GetDatabase(settings.DataBaseName);
            Collection = Database.GetCollection<LogModel>(settings.CollectionName);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
