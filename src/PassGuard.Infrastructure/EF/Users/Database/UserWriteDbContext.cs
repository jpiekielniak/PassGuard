using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PassGuard.Infrastructure.EF.Users.Database;

internal sealed class UserWriteDbContext(DbContextOptions<UserWriteDbContext> options)
    : IdentityDbContext<IdentityUser>(options)
{
    private const string Schema = "identity";
    public DbSet<IdentityUser> Users => Set<IdentityUser>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema(Schema);
    }
}