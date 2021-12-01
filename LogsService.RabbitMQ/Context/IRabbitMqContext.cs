using RabbitMQ.Client;

namespace LogsService.RabbitMQ.Context
{
    public interface IRabbitMqContext
    {
        IConnection GetRabbitConnection();
    }
}
