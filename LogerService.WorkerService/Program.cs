using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using LogsService.FluentJobManager;
using LogsService.Common.Configs;
using LogsService.Common.Configs.Implementations;
using LogsService.Common.Configs.Interfaces;

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

                    services.AddSingleton<IMongoDatabaseConfiguration, MongoDatabaseConfiguration>();

                    services.AddHostedService<WorkerService>();
                });
    }
}
