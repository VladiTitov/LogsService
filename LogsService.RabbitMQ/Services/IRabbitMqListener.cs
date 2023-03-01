using RabbitMQ.Client.Events;

namespace LogsService.RabbitMQ.Services
{
    public interface IRabbitMqListener
    {
        void ChannelConsume();
        EventingBasicConsumer GetConsumer();
    }
}
