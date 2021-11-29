using System.Threading.Tasks;
using LogsService.Common.Configs;
using LogsService.Common.Models;
using LogsService.DataAccess.Mongo.Context;

namespace LogsService.DataAccess.Mongo.Repositories
{
    public class MongoRepository : IMongoRepository
    {
        private readonly Settings _settings;

        public MongoRepository(Settings settings)
        {
            _settings = settings;
        }

        public async Task Add(LogModel item)
        {
            using (var db = new MongoContext(_settings))
            {
                await db.Collection.InsertOneAsync(item);
            }
        }
    }
}
