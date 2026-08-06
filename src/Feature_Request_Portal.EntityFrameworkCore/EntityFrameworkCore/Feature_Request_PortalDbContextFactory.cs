using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Feature_Request_Portal.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class Feature_Request_PortalDbContextFactory : IDesignTimeDbContextFactory<Feature_Request_PortalDbContext>
{
    public Feature_Request_PortalDbContext CreateDbContext(string[] args)
    {
        // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
        var configuration = BuildConfiguration();
        
        Feature_Request_PortalEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<Feature_Request_PortalDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"));
        
        return new Feature_Request_PortalDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Feature_Request_Portal.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables();

        return builder.Build();
    }
}
