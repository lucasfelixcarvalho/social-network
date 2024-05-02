using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DbContexts;

namespace Persistence;

public static class PersistenceModule
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("SocialNetworkDb");
        services.AddDbContext<SocialNetworkDbContext>(o => o.UseSqlServer(connectionString));

        return services;
    }
}
