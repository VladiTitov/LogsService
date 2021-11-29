using System.Threading.Tasks;
using LogsService.Common.Models;
using LogsService.DataAccess.Mongo.Context;

namespace LogsService.DataAccess.Mongo.Repositories
{
    public class MongoRepository : IMongoRepository
    {
        private readonly IMongoContext _mongoContext;

        public MongoRepository(IMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public async Task Add(LogModel item)
        {
            await _mongoContext.Collection.InsertOneAsync(item);
        }
    }
}
