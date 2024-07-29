using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtodoksNorge.Shared.Configuration.Database;
public sealed class DatabaseSection
{
    public string ConnectionString { get; set; } = "KeyVault";
    public Dictionary<string, IdentityColumnConfig> IdentityColumnConfigs { get; set; } = new();
    public string MigrationsSchema { get; set; } = string.Empty;
    public string MigrationsAssembly { get; set; } = string.Empty;
    public string MigrationsTable { get; set; } = string.Empty;
}
