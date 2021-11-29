using LogsService.Common.Configs.Interfaces;
using Microsoft.Extensions.Options;

namespace LogsService.Common.Configs.Implementations
{
    public class MongoDatabaseConfiguration : IMongoDatabaseConfiguration
    {
        public MongoDatabaseConfiguration(IOptions<ConfigMongoDb> options)
        {
            this.CollectionName = options.Value.CollectionName;
            this.DataBaseName = options.Value.DataBaseName;
            this.Server = options.Value.Server;
            this.Port = options.Value.Port;

            this.ConnectionString = $"mongodb://{Server}:{Port}/{DataBaseName}";
        }

        public string CollectionName { get; set; }
        public string DataBaseName { get; set; }
        public string Server { get; set; }
        public string Port { get; set; }
        public string ConnectionString { get; set; }
    }
}
