using FluentScheduler;
using LogsService.Common.Configs;
using LogsService.Common.Models;
using LogsService.DataAccess.Mongo.Repositories;

namespace LogsService.FluentJobManager.Jobs
{
    public class RabbitMqConsumerData : IJob
    {
        private readonly Settings _settings;
        private IMongoRepository _mongoRepository;

        public RabbitMqConsumerData(Settings settings)
        {
            _settings = settings;
        }

        public async void Execute()
        {
            _mongoRepository = new MongoRepository(_settings);
            await _mongoRepository.Add(new LogModel {Info = "First label"});
        }
    }
}
