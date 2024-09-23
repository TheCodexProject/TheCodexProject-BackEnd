using domain.models.shared;
using domain.models.user;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCorePersistence.Config;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Primary Key
        builder.HasKey(t => t.Id);
        
        // Value Converter for ID<User> to Guid
        var idValueConverter = new ValueConverter<Id<User>, Guid>(
            id => id.Value, // Convert ID<User> to Guid
            dbValue => Id<User>.FromGuid(dbValue)// Convert Guid to ID<User>
        );
        
        // Id property configuration
        builder.Property(t => t.Id)
            .HasConversion(idValueConverter);
        
        // FirstName property configuration
        builder.OwnsOne(t => t.FirstName, firstName =>
        {
            firstName.Property(t => t.Value)
                .HasColumnName("FirstName")
                .HasMaxLength(75)
                .IsRequired();
        });
        
        // LastName property configuration
        builder.OwnsOne(t => t.LastName, lastName =>
        {
            lastName.Property(t => t.Value)
                .HasColumnName("LastName")
                .HasMaxLength(75)
                .IsRequired();
        });
        
        // Email property configuration
        builder.OwnsOne(t => t.Email, email =>
        {
            email.Property(t => t.Value)
                .HasColumnName("Email")
                .HasMaxLength(75)
                .IsRequired();
        });
        
        // Additional configuration
        builder.ToTable("Users");
        
        



    }
}