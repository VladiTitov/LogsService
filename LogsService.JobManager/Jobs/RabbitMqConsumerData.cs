using FluentScheduler;
using LogsService.RabbitMQ.Services;

namespace LogsService.FluentJobManager.Jobs
{
    public class RabbitMqConsumerData : IJob
    {
        private readonly IRabbitMqListener _listener;

        public RabbitMqConsumerData(IRabbitMqListener listener)
        {
            _listener = listener;
        }

        public void Execute()
        {
            _listener.ChannelConsume();
        }
    }
}
