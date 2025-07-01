using FiestApp_Infrastructure.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestApp_Infrastructure.Context.Configurations;

public class RideConfiguration : IEntityTypeConfiguration<RideDocument>
{
    public void Configure(EntityTypeBuilder<RideDocument> builder)
    {
        builder.ToTable("rides");
        builder.HasKey(r => r.Guid);

        builder.Property(r => r.Guid).HasColumnName("guid").HasMaxLength(36).IsRequired();
        builder.Property(r => r.EventGuid).HasColumnName("event_guid").HasMaxLength(36).IsRequired();
        builder.Property(r => r.DriverGuid).HasColumnName("driver_guid").HasMaxLength(36).IsRequired();
        builder.Property(r => r.PassengerGuid).HasColumnName("passenger_guid").HasMaxLength(36);
        builder.Property(r => r.AvailableSlots).HasColumnName("avaliable_slots").IsRequired().IsRequired();
        builder.Property(r => r.Status).HasColumnName("status").HasMaxLength(2).IsRequired();
        builder.Property(r => r.CreatedAtUnixTimestamp).HasColumnName("created_at").IsRequired();
        builder.Property(r => r.UpdatedAtUnixTimestamp).HasColumnName("updated_at").IsRequired();

        builder.HasOne(r => r.Event)
               .WithMany()
               .HasForeignKey(r => r.EventGuid)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Driver)
               .WithMany()
               .HasForeignKey(r => r.DriverGuid)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Passenger)
               .WithMany()
               .HasForeignKey(r => r.PassengerGuid)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
