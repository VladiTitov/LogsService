using System;
using FluentScheduler;

namespace LogsService.JobManager.Jobs
{
    public class RabbitMqConsumerData : IJob
    {
        public void Execute()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
