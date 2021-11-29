using FluentScheduler;
using LogsService.JobManager.Jobs;

namespace LogsService.JobManager
{
    public class JobRegistryService : Registry
    {
        public JobRegistryService()
        {
            Schedule(() => new RabbitMqConsumerData())
                .NonReentrant()
                .ToRunNow()
                .AndEvery(10)
                .Seconds();
        }
    }
}
