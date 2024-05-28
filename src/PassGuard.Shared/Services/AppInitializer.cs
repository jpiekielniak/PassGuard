using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PassGuard.Shared.Services;

internal class AppInitializer(IServiceProvider serviceProvider, ILogger<AppInitializer> logger) 
    : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var dbContextTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(DbContext).IsAssignableFrom(x) && !x.IsInterface && x != typeof(DbContext));

        using var scope = serviceProvider.CreateScope();
        foreach (var dbContextType in dbContextTypes)
        {
            if (scope.ServiceProvider.GetService(dbContextType) is not DbContext dbContext)
                continue;

            await dbContext.Database.MigrateAsync(cancellationToken);
            logger.LogInformation("Migrated database associated with context {Name}", dbContext.GetType().Name);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}