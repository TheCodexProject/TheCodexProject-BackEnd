using domain.models.user;
using domain.models.workItem;
using EFCorePersistence.Config;
using Microsoft.EntityFrameworkCore;

namespace EFCorePersistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<WorkItem> WorkItems { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new WorkItemConfiguration());
        // Apply other configurations as needed

        base.OnModelCreating(modelBuilder);
    }
}