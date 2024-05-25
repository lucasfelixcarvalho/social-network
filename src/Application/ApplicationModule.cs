using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddServices();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<IConnectionService, ConnectionService>();

        return services;
    }
}
