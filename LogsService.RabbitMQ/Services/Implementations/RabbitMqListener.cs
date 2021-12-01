using System;
using System.Text;
using LogsService.Common.Configs;
using LogsService.RabbitMQ.Context;
using LogsService.RabbitMQ.Services.Interfaces;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace LogsService.RabbitMQ.Services.Implementations
{
    public class RabbitMqListener : IRabbitMqListener
    {
        private readonly RabbitMqConfiguration _rabbitMqConfiguration;

        private readonly IRabbitMqContext _context;

        public RabbitMqListener(IRabbitMqContext context, IOptions<RabbitMqConfiguration> rabbitMqConfiguration)
        {
            _context = context;
            _rabbitMqConfiguration = rabbitMqConfiguration.Value;
        }

        public void Connect()
        {
            using (var connection = _context.GetRabbitConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "logs-queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (sender, e) =>
                {
                    var body = e.Body;
                    var message = Encoding.UTF8.GetString(body.ToArray());

                    Console.WriteLine($"Message - {message}");
                };

                channel.BasicConsume(queue: "logs-queue", autoAck: true, consumer);
            }
        }
    }
}
