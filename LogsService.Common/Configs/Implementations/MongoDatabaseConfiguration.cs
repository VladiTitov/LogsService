using LogsService.Common.Configs.Interfaces;

namespace LogsService.Common.Configs.Implementations
{
    public class MongoDatabaseConfiguration : IMongoDatabaseConfiguration
    {
        public string CollectionName { get; set; }
        public string DataBaseName { get; set; }
        public string Server { get; set; }
        public string Port { get; set; }
    }
}
