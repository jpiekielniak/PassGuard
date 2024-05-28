using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PassGuard.Core.Entities;

namespace PassGuard.Infrastructure.EF.Credentials.Database.Configurations;

internal sealed class CredentialEntityWriteConfiguration : IEntityTypeConfiguration<Credential>
{
    public void Configure(EntityTypeBuilder<Credential> builder)
    {
        builder.HasKey(credential => credential.Id);
        
        builder
            .Property(credential => credential.UserId)
            .IsRequired();
        
        builder
            .Property(credential => credential.Website)
            .IsRequired();
        
        builder
            .Property(credential => credential.Username)
            .IsRequired(false);
        
        builder.
            Property(credential => credential.Password)
            .IsRequired();
        
        builder
            .Property(credential => credential.Notes).
            IsRequired(false);
        
        builder
            .Property(credential => credential.CreatedAt)
            .IsRequired();
        
        builder
            .Property(credential => credential.UpdatedAt)
            .IsRequired(false);
        
        builder.ToTable("credentials");
    }
}