using FiestApp_Infrastructure.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FiestApp_Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<UserDocument> Users { get; set; }
    // Ajoutez d'autres DbSet ici

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuration des entités
        modelBuilder.Entity<UserDocument>(entity =>
        {
            entity.HasKey(e => e.Guid);
            entity.Property(e => e.Username).HasMaxLength(50).IsRequired();
            entity.HasIndex(e => e.Username).IsUnique();

            // Configuration automatique des timestamps
            entity.Property(e => e.CreatedAtUnixTimestamp).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        // Appliquer toutes les configurations dans l'assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Mise à jour automatique des timestamps
        var entries = ChangeTracker.Entries<DocumentBase>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAtUnixTimestamp = DateTime.UtcNow.Ticks;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}