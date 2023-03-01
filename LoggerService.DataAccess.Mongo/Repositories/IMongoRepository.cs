using System.Threading.Tasks;
using LogsService.Common.Models;

namespace LogsService.DataAccess.Mongo.Repositories
{
    public interface IMongoRepository
    {
        Task Add(LogModel item);
    }
}
