using FiestApp_Infrastructure.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestApp_Infrastructure.Context.Configurations;

public class ShoppingItemConfiguration : IEntityTypeConfiguration<ShoppingItemDocument>
{
    public void Configure(EntityTypeBuilder<ShoppingItemDocument> builder)
    {
        builder.ToTable("shopping_items");
        builder.HasKey(si => si.Guid);

        builder.Property(si => si.Guid).HasColumnName("guid").HasMaxLength(36).IsRequired();
        builder.Property(si => si.ShoppingListGuid).HasColumnName("list_guid").HasMaxLength(36);
        builder.Property(si => si.Name).HasColumnName("name").HasMaxLength(255).IsRequired();
        builder.Property(si => si.Quantity).HasColumnName("quantity").IsRequired();
        builder.Property(si => si.IconGuid).HasColumnName("icon_guid").HasMaxLength(36).IsRequired();
        builder.Property(si => si.AssignedToGuid).HasColumnName("assigned_to").HasMaxLength(36);
        builder.Property(si => si.IsBought).HasColumnName("is_bought").HasDefaultValue(false);
        builder.Property(si => si.CreatedAtUnixTimestamp).HasColumnName("created_at").IsRequired();
        builder.Property(si => si.UpdatedAtUnixTimestamp).HasColumnName("updated_at").IsRequired();

        builder.HasOne(si => si.ShoppingList)
               .WithMany()
               .HasForeignKey(si => si.ShoppingListGuid)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(si => si.AssignedUser)
               .WithMany()
               .HasForeignKey(si => si.AssignedToGuid)
               .OnDelete(DeleteBehavior.SetNull);
    }
}