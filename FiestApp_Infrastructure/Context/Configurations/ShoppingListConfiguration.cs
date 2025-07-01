using FiestApp_Infrastructure.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestApp_Infrastructure.Context.Configurations;

public class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingListDocument>
{
    public void Configure(EntityTypeBuilder<ShoppingListDocument> builder)
    {
        builder.ToTable("shopping_lists");
        builder.HasKey(sl => sl.Guid);

        builder.Property(sl => sl.Guid).HasColumnName("guid").HasMaxLength(36).IsRequired();
        builder.Property(sl => sl.EventGuid).HasColumnName("event_guid").HasMaxLength(36);
        builder.Property(sl => sl.CreatedAtUnixTimestamp).HasColumnName("created_at").IsRequired();
        builder.Property(sl => sl.UpdatedAtUnixTimestamp).HasColumnName("updated_at").IsRequired();

        builder.HasOne(sl => sl.Event)
               .WithMany()
               .HasForeignKey(sl => sl.EventGuid)
               .OnDelete(DeleteBehavior.Cascade);
    }
}