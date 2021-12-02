using System.Text;
using LogsService.Common.Configs;
using LogsService.Common.Models;
using LogsService.DataAccess.Mongo.Repositories;
using LogsService.RabbitMQ.Context;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace LogsService.RabbitMQ.Services
{
    public class RabbitMqListener : IRabbitMqListener
    {
        private readonly IMongoRepository _mongoRepository;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName;

        public RabbitMqListener(IRabbitMqContext context, IMongoRepository mongoRepository, IOptions<RabbitMqConfiguration> configuration)
        {
            _mongoRepository = mongoRepository;
            _connection = context.Connection;
            _channel = _connection.CreateModel();
            _queueName = configuration.Value.QueueName;
        }

        public void ChannelConsume()
        {
            _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            _channel.BasicConsume(queue: _queueName, autoAck: true, GetConsumer());
        }


        public EventingBasicConsumer GetConsumer()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());
                _mongoRepository.Add(new LogModel { Info = message });
            };
            return consumer;
        }
    }
}
