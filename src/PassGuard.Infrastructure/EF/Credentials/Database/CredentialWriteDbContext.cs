using Microsoft.EntityFrameworkCore;
using PassGuard.Core.Entities;
using PassGuard.Infrastructure.EF.Credentials.Database.Configurations;

namespace PassGuard.Infrastructure.EF.Credentials.Database;

public sealed class CredentialWriteDbContext(DbContextOptions<CredentialWriteDbContext> options) 
    : DbContext(options)
{
    private const string Schema = "credentials";
    public DbSet<Credential> Credentials => Set<Credential>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfiguration(new CredentialEntityWriteConfiguration());
    }
}