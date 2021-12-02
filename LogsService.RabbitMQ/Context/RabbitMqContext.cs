using LogsService.Common.Configs;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace LogsService.RabbitMQ.Context
{
    public class RabbitMqContext : IRabbitMqContext
    {
        private readonly RabbitMqConfiguration _rabbitMqConfiguration;

        public IConnection Connection => GetRabbitConnection();

        public RabbitMqContext(IOptions<RabbitMqConfiguration> rabbitMqConfiguration)
        {
            _rabbitMqConfiguration = rabbitMqConfiguration.Value;
        }

        public IConnection GetRabbitConnection()
        {
            var factory = new ConnectionFactory()
            {
                UserName = _rabbitMqConfiguration.UserName,
                Password = _rabbitMqConfiguration.Password,
                Port = _rabbitMqConfiguration.Port,
                VirtualHost = "/",
                HostName = _rabbitMqConfiguration.Hostname
            };

            return factory.CreateConnection();
        }
    }
}
