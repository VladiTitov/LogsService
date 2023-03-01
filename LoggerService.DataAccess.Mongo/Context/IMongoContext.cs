using LogsService.Common.Models;
using MongoDB.Driver;

namespace LogsService.DataAccess.Mongo.Context
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; set; }
        IMongoCollection<LogModel> Collection { get; set; }
    }
}
