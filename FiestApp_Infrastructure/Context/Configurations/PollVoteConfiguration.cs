using FiestApp_Infrastructure.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestApp_Infrastructure.Context.Configurations;

public class PollVoteConfiguration : IEntityTypeConfiguration<PollVoteDocument>
{
    public void Configure(EntityTypeBuilder<PollVoteDocument> builder)
    {
        builder.ToTable("poll_votes");
        builder.HasKey(pv => pv.Guid);

        builder.Property(pv => pv.Guid).HasColumnName("guid").HasMaxLength(36).IsRequired();
        builder.Property(pv => pv.PollGuid).HasColumnName("poll_guid").HasMaxLength(36);
        builder.Property(pv => pv.UserGuid).HasColumnName("user_guid").HasMaxLength(36);
        builder.Property(pv => pv.PollOptionGuid).HasColumnName("option_id").HasMaxLength(36);
        builder.Property(pv => pv.CreatedAtUnixTimestamp).HasColumnName("created_at").IsRequired();
        builder.Property(pv => pv.UpdatedAtUnixTimestamp).HasColumnName("updated_at").IsRequired();

        builder.HasIndex(pv => new { pv.PollGuid, pv.UserGuid }).IsUnique();

        builder.HasOne(pv => pv.Poll)
               .WithMany()
               .HasForeignKey(pv => pv.PollGuid)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pv => pv.User)
               .WithMany()
               .HasForeignKey(pv => pv.UserGuid)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pv => pv.Option)
               .WithMany()
               .HasForeignKey(pv => pv.PollOptionGuid)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
