using System;
using System.Threading;
using System.Threading.Tasks;
using FluentScheduler;
using LogsService.JobManager;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LoggerService.WorkerService
{
    class WorkerService : IHostedService
    {
        private readonly ILogger<WorkerService> _logger;

        public WorkerService(ILogger<WorkerService> logger, 
            JobRegistryService jobRegistryService)
        {
            _logger = logger;
            JobManager.Initialize(jobRegistryService);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"JobManager was started {DateTimeOffset.Now}");
            JobManager.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"JobManager was stopped {DateTimeOffset.Now}");
            JobManager.Stop();
            return Task.CompletedTask;
        }
    }
}
