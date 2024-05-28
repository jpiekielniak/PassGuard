using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PassGuard.Infrastructure.EF.Credentials.Database;
using PassGuard.Infrastructure.EF.Users.Database;
using PassGuard.Shared.Postgres;

[assembly: InternalsVisibleTo("PassGuard.Api")]
namespace PassGuard.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddPostgres<UserWriteDbContext>()
            .AddPostgres<CredentialWriteDbContext>();

        services
            .AddIdentityApiEndpoints<IdentityUser>()
            .AddEntityFrameworkStores<UserWriteDbContext>();

        return services;
    }
}