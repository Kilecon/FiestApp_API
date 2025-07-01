using FiestApp_Infrastructure.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestApp_Infrastructure.Context.Configurations;

public class DesignatedDriverConfiguration : IEntityTypeConfiguration<DesignatedDriverDocument>
{
    public void Configure(EntityTypeBuilder<DesignatedDriverDocument> builder)
    {
        builder.ToTable("designated_drivers");
        builder.ToTable("designated_drivers", t =>
        {
            t.HasCheckConstraint("CK_designated_drivers_status", "status IN ('PD', 'OK', 'KO')");
        });
        builder.HasKey(dd => dd.Guid);

        builder.Property(dd => dd.Guid).HasColumnName("guid").HasMaxLength(36).IsRequired();
        builder.Property(dd => dd.EventGuid).HasColumnName("event_guid").HasMaxLength(36);
        builder.Property(dd => dd.DriverGuid).HasColumnName("sam_guid").HasMaxLength(36);
        builder.Property(dd => dd.Status).HasColumnName("status").HasMaxLength(2);
        builder.Property(dd => dd.CreatedAtUnixTimestamp).HasColumnName("created_at").IsRequired();
        builder.Property(dd => dd.UpdatedAtUnixTimestamp).HasColumnName("updated_at").IsRequired();

        builder.HasOne(dd => dd.Event)
               .WithMany()
               .HasForeignKey(dd => dd.EventGuid)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(dd => dd.Driver)
               .WithMany()
               .HasForeignKey(dd => dd.DriverGuid)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
