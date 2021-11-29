namespace LogsService.Common.Configs.Interfaces
{
    public interface IMongoDatabaseConfiguration
    {
        string CollectionName { get; set; }
        string DataBaseName { get; set; }
        string Server { get; set; }
        string Port { get; set; }
    }
}
