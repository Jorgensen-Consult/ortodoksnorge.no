using Microsoft.EntityFrameworkCore;
using OrtodoksNorge.Shared.Configuration.Database;
using OrtodoksNorge.Shared.DbContexts;

namespace OrtodoksNorge.Web.Startup;

public static class DatabaseStartup
{
    public static void AddSiteDbContext<T>(this IServiceCollection services, T config)
        where T : IDatabaseConfiguration
    {
        services.AddDbContext<SiteDbContext>(o =>
        {
            o.UseSqlServer(config.Database.ConnectionString, p =>
            {
                p.MigrationsAssembly(config.Database.MigrationsAssembly);
                p.MigrationsHistoryTable(config.Database.MigrationsTable, config.Database.MigrationsSchema);
            });
        });
    }
}
