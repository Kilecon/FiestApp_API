using FiestApp_Infrastructure.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FiestApp_Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    //public DbSet<UserDocument> Users { get; set; }
    //public DbSet<EventDocument> Events { get; set; }
    //public DbSet<InvitationDocument> Invitations { get; set; }
    //public DbSet<PollDocument> Polls { get; set; }
    //public DbSet<PollOptionDocument> PollOptions { get; set; }
    //public DbSet<PollVoteDocument> PollVotes { get; set; }
    //public DbSet<ShoppingListDocument> ShoppingLists { get; set; }
    //public DbSet<ShoppingItemDocument> ShoppingItems { get; set; }
    //public DbSet<AccommodationDocument> Accommodations { get; set; }
    //public DbSet<DesignatedDriverDocument> DesignatedDrivers { get; set; }
    //public DbSet<RideDocument> Rides { get; set; }
    //public DbSet<ExpenseDocument> Expenses { get; set; }
    //public DbSet<ExpenseShareDocument> ExpenseShares { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new EventConfiguration());
        modelBuilder.ApplyConfiguration(new InvitationConfiguration());
        modelBuilder.ApplyConfiguration(new PollConfiguration());
        modelBuilder.ApplyConfiguration(new PollOptionConfiguration());
        modelBuilder.ApplyConfiguration(new PollVoteConfiguration());
        modelBuilder.ApplyConfiguration(new ShoppingListConfiguration());
        modelBuilder.ApplyConfiguration(new ShoppingItemConfiguration());
        modelBuilder.ApplyConfiguration(new AccommodationConfiguration());
        modelBuilder.ApplyConfiguration(new RideConfiguration());
        modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
        modelBuilder.ApplyConfiguration(new ExpenseShareConfiguration());

    }
}