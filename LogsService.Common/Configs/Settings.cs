using LogsService.Common.Extensions;
using Microsoft.Extensions.Configuration;

namespace LogsService.Common.Configs
{
    public class Settings
    {
        private readonly IConfiguration _configuration;

        public Settings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int RunInterval => _configuration["RunInterval"].GetValidRunInterval();
    }
}
