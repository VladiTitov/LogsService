using FluentScheduler;
using LogsService.DataAccess.Mongo.Repositories;
using LogsService.RabbitMQ.Services.Interfaces;

namespace LogsService.FluentJobManager.Jobs
{
    public class RabbitMqConsumerData : IJob
    {
        private readonly IMongoRepository _mongoRepository;
        private readonly IRabbitMqListener _rabbitMqListener;

        public RabbitMqConsumerData(IMongoRepository mongoRepository, IRabbitMqListener rabbitMqListener)
        {
            _mongoRepository = mongoRepository;
            _rabbitMqListener = rabbitMqListener;
        }

        public async void Execute()
        {
            _rabbitMqListener.Connect();

            //await _mongoRepository.Add(new LogModel {Info = "First label"});
        }
    }
}
