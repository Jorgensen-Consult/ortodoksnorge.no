using OrtodoksNorge.Web.Configuration;
using Azure.Identity;
using OrtodoksNorge.Shared.Configuration.Database;

namespace OrtodoksNorge.Web.Startup;

public static class ConfigurationStartup
{
    public static void AddConfigurationWithKeyvault(this WebApplicationBuilder builder, AppSettings config)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();
        builder.Configuration.AddConfiguration(configuration);
        builder.Configuration.AddAzureKeyVault(builder.Configuration.GetValue(typeof(Uri), "Azure:KeyVaultUri") as Uri, new DefaultAzureCredential());
        builder.Configuration.Bind(config);
        builder.Services.AddSingleton<IDatabaseConfiguration>(config);
    }
}
