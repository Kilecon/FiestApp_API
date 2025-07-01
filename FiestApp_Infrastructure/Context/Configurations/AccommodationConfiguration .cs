using FiestApp_Infrastructure.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestApp_Infrastructure.Context.Configurations;

public class AccommodationConfiguration : IEntityTypeConfiguration<AccommodationDocument>
{
    public void Configure(EntityTypeBuilder<AccommodationDocument> builder)
    {
        builder.HasKey(a => a.Guid);

        builder.Property(a => a.Guid).HasColumnName("guid").HasMaxLength(36).IsRequired();
        builder.Property(a => a.EventGuid).HasColumnName("event_guid").HasMaxLength(36).IsRequired();
        builder.Property(a => a.HostGuid).HasColumnName("host_guid").HasMaxLength(36).IsRequired();
        builder.Property(a => a.GuestGuid).HasColumnName("guest_guid").HasMaxLength(36);
        builder.Property(r => r.Status).HasColumnName("status").HasMaxLength(2).IsRequired();
        builder.Property(r => r.AvailableSlots).HasColumnName("avaliable_slots").IsRequired();
        builder.Property(a => a.CreatedAtUnixTimestamp).HasColumnName("created_at").IsRequired();
        builder.Property(a => a.UpdatedAtUnixTimestamp).HasColumnName("updated_at").IsRequired();

        builder.HasOne(a => a.Event)
               .WithMany()
               .HasForeignKey(a => a.EventGuid)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.Host)
               .WithMany()
               .HasForeignKey(a => a.HostGuid)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Guest)
               .WithMany()
               .HasForeignKey(a => a.GuestGuid)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
