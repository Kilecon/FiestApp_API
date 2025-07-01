using FiestApp_Infrastructure.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestApp_Infrastructure.Context.Configurations;

public class PollConfiguration : IEntityTypeConfiguration<PollDocument>
{
    public void Configure(EntityTypeBuilder<PollDocument> builder)
    {
        builder.ToTable("polls", t =>
        {
            t.HasCheckConstraint("CK_polls_status", "status IN ('PD', 'OK', 'KO')");
        });
        builder.HasKey(p => p.Guid);

        builder.Property(p => p.Guid).HasColumnName("guid").HasMaxLength(36).IsRequired();
        builder.Property(p => p.EventGuid).HasColumnName("event_guid").HasMaxLength(36);
        builder.Property(p => p.Question).HasColumnName("question").HasMaxLength(255).IsRequired();
        builder.Property(p => p.Status).HasColumnName("status").HasMaxLength(2);
        builder.Property(p => p.CreatedAtUnixTimestamp).HasColumnName("created_at").IsRequired();
        builder.Property(p => p.UpdatedAtUnixTimestamp).HasColumnName("updated_at").IsRequired();

        builder.HasOne(p => p.Event)
               .WithMany()
               .HasForeignKey(p => p.EventGuid)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
