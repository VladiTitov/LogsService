using FluentScheduler;
using LogsService.Common.Configs;

namespace LogsService.FluentJobManager
{
    public class JobRegistryService : Registry
    {
        public JobRegistryService(Settings settings, IJob job)
        {
            Schedule(() => job)
                .NonReentrant()
                .ToRunNow()
                .AndEvery(settings.RunInterval)
                .Seconds();

        }
    }
}
