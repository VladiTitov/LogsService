using System;
using LogsService.Common.Configs;
using LogsService.Common.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LogsService.DataAccess.Mongo.Context
{
    public class MongoContext : IMongoContext, IDisposable
    {
        public IMongoDatabase Database { get; set; }
        public IMongoCollection<LogModel> Collection { get; set; }

        public MongoContext(IOptions<MongoDatabaseConfiguration> mongoDatabaseConfiguration)
        {
            var client = new MongoClient(mongoDatabaseConfiguration.Value.ConnectionString);

            Database = client.GetDatabase(mongoDatabaseConfiguration.Value.DataBaseName);
            Collection = Database.GetCollection<LogModel>(mongoDatabaseConfiguration.Value.CollectionName);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
