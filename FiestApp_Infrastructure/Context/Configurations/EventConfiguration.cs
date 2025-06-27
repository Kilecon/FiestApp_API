using FiestApp_Infrastructure.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestApp_Infrastructure.Context.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<EventDocument>
{
    public void Configure(EntityTypeBuilder<EventDocument> builder)
    {
        builder.ToTable("events");
        builder.HasKey(e => e.Guid);

        builder.Property(e => e.Guid).HasColumnName("guid").HasMaxLength(36).IsRequired();
        builder.Property(e => e.Title).HasColumnName("title").HasMaxLength(50).IsRequired();
        builder.Property(e => e.Description).HasColumnName("description");
        builder.Property(e => e.Location).HasColumnName("location").HasMaxLength(255);
        builder.Property(e => e.Latitude).HasColumnName("latitude");
        builder.Property(e => e.Longitude).HasColumnName("longitude");
        builder.Property(e => e.Date).HasColumnName("date").IsRequired();
        builder.Property(e => e.CreatedAtUnixTimestamp).HasColumnName("created_at").IsRequired();
        builder.Property(e => e.UpdatedAtUnixTimestamp).HasColumnName("updated_at").IsRequired();
        builder.Property(e => e.CreatorGuid).HasColumnName("organizer_guid").HasMaxLength(36);

        builder.HasOne(e => e.Creator)
       .WithMany()
       .HasForeignKey(e => e.Creator)
       .OnDelete(DeleteBehavior.Cascade);

    }
}
