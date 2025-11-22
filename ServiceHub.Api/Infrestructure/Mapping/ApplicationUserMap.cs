using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceHub.Api.Infrestructure.Entity;

namespace ServiceHub.Api.Infrestructure.EntitiesMapping;

public class ApplicationUserMap : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
        
        builder.Property(u => u.Id)
            .HasMaxLength(36);
    }
}