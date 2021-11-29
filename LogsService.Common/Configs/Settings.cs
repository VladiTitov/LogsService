using LogsService.Common.Configs.Interfaces;
using LogsService.Common.Extensions;
using Microsoft.Extensions.Configuration;

namespace LogsService.Common.Configs
{
    public class Settings
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabaseConfiguration _mongoDatabaseConfiguration;

        public Settings(IConfiguration configuration, IMongoDatabaseConfiguration mongoDatabaseConfiguration)
        {
            _configuration = configuration;
            _mongoDatabaseConfiguration = mongoDatabaseConfiguration;
            _configuration.GetSection("MongoParams").Bind(_mongoDatabaseConfiguration);
        }

        public int RunInterval => _configuration["RunInterval"].GetValidRunInterval();
        public string CollectionName => _mongoDatabaseConfiguration.CollectionName;
        public string DataBaseName => _mongoDatabaseConfiguration.DataBaseName;
        public string Server => _mongoDatabaseConfiguration.Server;
        public string Port => _mongoDatabaseConfiguration.Port;
        public string ConnectionString => $"mongodb://{Server}:{Port}/{DataBaseName}";
    }
}
