using OrtodoksNorge.Shared.Configuration.Database;

namespace OrtodoksNorge.Shared.Configuration;

public abstract class AppSettingsBase : IDatabaseConfiguration
{
    public DatabaseSection Database { get; set; } = new();
}
