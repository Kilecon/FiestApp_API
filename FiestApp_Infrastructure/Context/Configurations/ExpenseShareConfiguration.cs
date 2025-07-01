using FiestApp_Infrastructure.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestApp_Infrastructure.Context.Configurations;

public class ExpenseShareConfiguration : IEntityTypeConfiguration<ExpenseShareDocument>
{
    public void Configure(EntityTypeBuilder<ExpenseShareDocument> builder)
    {
        builder.ToTable("expense_shares", t =>
        {
            t.HasCheckConstraint("CK_expense_shares_status", "status IN ('PD', 'OK', 'KO')");
        });
        builder.HasKey(es => es.Guid);

        builder.Property(es => es.Guid).HasColumnName("guid").HasMaxLength(36).IsRequired();
        builder.Property(es => es.ExpenseGuid).HasColumnName("expense_guid").HasMaxLength(36);
        builder.Property(es => es.UserGuid).HasColumnName("user_guid").HasMaxLength(36);
        builder.Property(es => es.Status).HasColumnName("status").HasMaxLength(2);
        builder.Property(es => es.AmountSharedInCents).HasColumnName("share_amount_in_cents");
        builder.Property(es => es.CreatedAtUnixTimestamp).HasColumnName("created_at").IsRequired();
        builder.Property(es => es.UpdatedAtUnixTimestamp).HasColumnName("updated_at").IsRequired();

        builder.HasOne(es => es.Expense)
               .WithMany()
               .HasForeignKey(es => es.ExpenseGuid)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(es => es.User)
               .WithMany()
               .HasForeignKey(es => es.UserGuid)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
