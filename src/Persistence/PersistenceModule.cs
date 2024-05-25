using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DbContexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceModule
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("SocialNetworkDb");
        services.AddDbContext<SocialNetworkDbContext>(o => o.UseSqlServer(connectionString));

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IConnectionRepository, ConnectionRepository>();

        return services;
    }
}
