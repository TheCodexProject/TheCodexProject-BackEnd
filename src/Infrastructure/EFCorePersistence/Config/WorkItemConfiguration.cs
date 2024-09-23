using domain.models.shared;
using domain.models.user;
using domain.models.workItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCorePersistence.Config;

public class WorkItemConfiguration : IEntityTypeConfiguration<WorkItem>
{
    public void Configure(EntityTypeBuilder<WorkItem> builder)
    {
        // Primary Key
        builder.HasKey(t => t.Id);

        // Value Converter for ID<WorkItem> to Guid
        var idValueConverter = new ValueConverter<Id<WorkItem>, Guid>(
            id => id.Value, // Convert ID<WorkItem> to Guid
            dbValue => Id<WorkItem>.FromGuid(dbValue) // Convert Guid to ID<WorkItem>
        );

        // Id property configuration
        builder.Property(t => t.Id)
            .HasConversion(idValueConverter);

        // Metadata property configuration
        builder.OwnsOne(t => t.Metadata, metadata =>
        {
            metadata.Property(m => m.CreatedAt).HasColumnName("CreatedAt");
            metadata.Property(m => m.UpdatedAt).HasColumnName("UpdatedAt");
            metadata.Property(m => m.CreatedBy).HasColumnName("CreatedBy");
            metadata.Property(m => m.UpdatedBy).HasColumnName("UpdatedBy");
        });

        // Title property configuration
        builder.OwnsOne(t => t.Title, title =>
        {
            title.Property(t => t.Value)
                .HasColumnName("Title")
                .HasMaxLength(75)
                .IsRequired();
        });

        // Description property configuration
        builder.OwnsOne(t => t.Description, description =>
        {
            description.Property(d => d.Value)
                .HasColumnName("Description")
                .HasMaxLength(500)
                .IsRequired(false);
        });

        // Status property configuration
        builder.Property(w => w.Status)
            .HasConversion<string>()
            .HasColumnName("Status")
            .IsRequired(false);

        // Priority property configuration
        builder.Property(w => w.Priority)
            .HasConversion<string>()
            .HasColumnName("Priority")
            .IsRequired(false);

        // Type property configuration
        builder.Property(w => w.Type)
            .HasConversion<string>()
            .HasColumnName("Type")
            .IsRequired(false);

        // Value Converter for ID<User> to Guid for AssigneeId
        var userIdValueConverter = new ValueConverter<Id<User>, Guid>(
            id => id.Value, // Convert ID<User> to Guid
            dbValue => Id<User>.FromGuid(dbValue) // Convert Guid to ID<User>
        );

        // Assignee property configuration
        builder.HasOne(w => w.Assignee)
            .WithMany()
            .HasForeignKey("AssigneeId")
            .OnDelete(DeleteBehavior.SetNull)
            .IsRequired(false);

        builder.Property<Id<User>>("AssigneeId")
            .HasConversion(userIdValueConverter) // Use value converter for foreign key
            .HasColumnName("AssigneeId")
            .IsRequired(false);

        // Additional configuration
        builder.ToTable("WorkItems");


    }
}

