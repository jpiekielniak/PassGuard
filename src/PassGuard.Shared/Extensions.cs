using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using PassGuard.Shared.Services;

[assembly : InternalsVisibleTo("PassGuard.Api")]
namespace PassGuard.Shared;

internal static class Extensions
{
    public static IServiceCollection AddShared(this IServiceCollection services)
    {
        services
            .AddHostedService<AppInitializer>();

        return services;
    }
}