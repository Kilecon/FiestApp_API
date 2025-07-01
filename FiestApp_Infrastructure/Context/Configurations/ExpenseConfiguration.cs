using FiestApp_Infrastructure.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestApp_Infrastructure.Context.Configurations;

public class ExpenseConfiguration : IEntityTypeConfiguration<ExpenseDocument>
{
    public void Configure(EntityTypeBuilder<ExpenseDocument> builder)
    {
        builder.ToTable("expenses");
        builder.HasKey(e => e.Guid);

        builder.Property(e => e.Guid).HasColumnName("guid").HasMaxLength(36).IsRequired();
        builder.Property(e => e.EventGuid).HasColumnName("event_guid").HasMaxLength(36);
        builder.Property(e => e.PayerGuid).HasColumnName("payer_guid").HasMaxLength(36);
        builder.Property(e => e.Label).HasColumnName("label").HasMaxLength(255);
        builder.Property(e => e.AmountInCents).HasColumnName("amount_in_cents").IsRequired();
        builder.Property(e => e.CreatedAtUnixTimestamp).HasColumnName("created_at").IsRequired();
        builder.Property(e => e.UpdatedAtUnixTimestamp).HasColumnName("updated_at").IsRequired();

        builder.HasOne(e => e.Event)
               .WithMany()
               .HasForeignKey(e => e.EventGuid)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Payer)
               .WithMany()
               .HasForeignKey(e => e.PayerGuid)
               .OnDelete(DeleteBehavior.Restrict);
    }
}