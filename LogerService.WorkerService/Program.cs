using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using LogsService.FluentJobManager;
using LogsService.Common.Configs;
using LogsService.Common.Configs.Implementations;
using LogsService.Common.Configs.Interfaces;
using LogsService.DataAccess.Mongo.Context;
using LogsService.DataAccess.Mongo.Repositories;
using FluentScheduler;
using LogsService.FluentJobManager.Jobs;

namespace LogsService.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureAppConfiguration(confBuilder =>
                {
                    confBuilder.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<Settings>();
                    services.AddSingleton<JobRegistryService>();               

                    services.Configure<ConfigMongoDb>(hostContext.Configuration.GetSection("MongoParams"));
                    services.AddSingleton<IMongoDatabaseConfiguration, MongoDatabaseConfiguration>();

                    services.AddSingleton<IMongoContext, MongoContext>();
                    services.AddSingleton<IMongoRepository, MongoRepository>();

                    services.AddSingleton<IJob, RabbitMqConsumerData>();

                    services.AddHostedService<WorkerService>();
                });
    }
}
