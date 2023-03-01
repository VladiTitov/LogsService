using FluentScheduler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using LogsService.Common.Configs;
using LogsService.FluentJobManager;
using LogsService.FluentJobManager.Jobs;
using LogsService.DataAccess.Mongo.Context;
using LogsService.DataAccess.Mongo.Repositories;
using LogsService.RabbitMQ.Context;
using LogsService.RabbitMQ.Services;

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
                    confBuilder.AddJsonFile("Configs/rabbitMq-config.json");
                    confBuilder.AddJsonFile("Configs/mongoDb-config.json");
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<Settings>();
                    services.AddSingleton<JobRegistryService>();               

                    services.Configure<MongoDatabaseConfiguration>(hostContext.Configuration.GetSection("MongoParams"));
                    services.Configure<RabbitMqConfiguration>(hostContext.Configuration.GetSection("RabbitParams"));

                    services.AddSingleton<IMongoContext, MongoContext>();
                    services.AddSingleton<IMongoRepository, MongoRepository>();

                    services.AddSingleton<IRabbitMqContext, RabbitMqContext>();
                    services.AddSingleton<IRabbitMqListener, RabbitMqListener>();

                    services.AddSingleton<IJob, RabbitMqConsumerData>();

                    services.AddHostedService<WorkerService>();
                });
    }
}
