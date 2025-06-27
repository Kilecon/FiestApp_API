using FiestApp_Infrastructure.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestApp_Infrastructure.Context.Configurations;

public class PollOptionConfiguration : IEntityTypeConfiguration<PollOptionDocument>
{
    public void Configure(EntityTypeBuilder<PollOptionDocument> builder)
    {
        builder.ToTable("poll_options");
        builder.HasKey(po => po.Guid);

        builder.Property(po => po.Guid).HasColumnName("guid").HasMaxLength(36).IsRequired();
        builder.Property(po => po.PollGuid).HasColumnName("poll_guid").HasMaxLength(36);
        builder.Property(po => po.Option).HasColumnName("option_text").HasMaxLength(255).IsRequired();
        builder.Property(po => po.CreatedAtUnixTimestamp).HasColumnName("created_at").IsRequired();
        builder.Property(po => po.UpdatedAtUnixTimestamp).HasColumnName("updated_at").IsRequired();

        builder.HasOne(po => po.Poll)
               .WithMany()
               .HasForeignKey(po => po.PollGuid)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
