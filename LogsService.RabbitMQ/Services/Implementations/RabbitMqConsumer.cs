using LogsService.DataAccess.Mongo.Repositories;
using LogsService.RabbitMQ.Services.Interfaces;

namespace LogsService.RabbitMQ.Services.Implementations
{
    public class RabbitMqConsumer : IRabbitMqConsumer
    {
        private readonly IMongoRepository _mongoRepository;
        private readonly IRabbitMqListener _rabbitMqListener;

        public RabbitMqConsumer(IMongoRepository mongoRepository, IRabbitMqListener rabbitMqListener)
        {
            _mongoRepository = mongoRepository;
            _rabbitMqListener = rabbitMqListener;
        }

        public void Execute()
        {
            _rabbitMqListener.Connect();
        }
    }
}
