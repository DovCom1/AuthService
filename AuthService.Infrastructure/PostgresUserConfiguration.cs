using AuthService.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthService.Infrastructure;

public class PostgresUserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");
        builder.HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .HasColumnName("id");
        
        builder
            .Property(u => u.Email)
            .HasColumnName("email")
            .IsRequired();
        
        builder
            .Property(u => u.HashPassword)
            .HasColumnName("hash_password")
            .IsRequired();
    }
}