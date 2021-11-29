using FluentScheduler;
using LogsService.Common.Configs;
using LogsService.FluentJobManager.Jobs;

namespace LogsService.FluentJobManager
{
    public class JobRegistryService : Registry
    {
        public JobRegistryService(Settings settings)
        {
            Schedule(() => new RabbitMqConsumerData(settings))
                .NonReentrant()
                .ToRunNow()
                .AndEvery(settings.RunInterval)
                .Seconds();
        }
    }
}
