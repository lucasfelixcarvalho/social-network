using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class PersistenceModule
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {

        return services;
    }
}
