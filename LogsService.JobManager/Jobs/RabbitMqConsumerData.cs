using FluentScheduler;
using LogsService.Common.Models;
using LogsService.DataAccess.Mongo.Repositories;

namespace LogsService.FluentJobManager.Jobs
{
    public class RabbitMqConsumerData : IJob
    {
        private readonly IMongoRepository _mongoRepository;

        public RabbitMqConsumerData(IMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async void Execute()
        {
            await _mongoRepository.Add(new LogModel {Info = "First label"});
        }
    }
}
