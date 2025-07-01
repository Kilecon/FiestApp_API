using FiestApp_Infrastructure.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestApp_Infrastructure.Context.Configurations;

public class InvitationConfiguration : IEntityTypeConfiguration<InvitationDocument>
{
    public void Configure(EntityTypeBuilder<InvitationDocument> builder)
    {
        builder.ToTable("invitations", t =>
        {
            t.HasCheckConstraint("CK_invitations_status", "status IN ('PD', 'OK', 'KO')"); t.HasCheckConstraint("CK_users_alcohol", "alcohol_consumption IN ('NE','OC','RG','VT','UN')");
        });
        builder.HasKey(i => i.Guid);

        builder.Property(i => i.Guid).HasColumnName("guid").HasMaxLength(36).IsRequired();
        builder.Property(i => i.UserGuid).HasColumnName("user_guid").HasMaxLength(36);
        builder.Property(i => i.EventGuid).HasColumnName("event_id").HasMaxLength(36);
        builder.Property(i => i.Status).HasColumnName("status").HasMaxLength(2);
        builder.Property(i => i.CreatedAtUnixTimestamp).HasColumnName("created_at").IsRequired();
        builder.Property(i => i.UpdatedAtUnixTimestamp).HasColumnName("updated_at").IsRequired();

        builder.HasOne(i => i.User)
               .WithMany()
               .HasForeignKey(i => i.UserGuid)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.Event)
               .WithMany()
               .HasForeignKey(i => i.EventGuid)
               .OnDelete(DeleteBehavior.Cascade);
    }
}