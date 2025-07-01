using FiestApp_Infrastructure.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestApp_Infrastructure.Context.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserDocument>
    {
        public void Configure(EntityTypeBuilder<UserDocument> builder)
        {
            builder.ToTable("users", t =>
            {
                t.HasCheckConstraint("CK_users_gender", "gender IN ('M', 'F', 'OT', 'PR', 'UN')");
                t.HasCheckConstraint("CK_users_alcohol", "alcohol_consumption IN ('NE','OC','RG','VT','UN')");
            });

            builder.HasKey(u => u.Guid);

            builder.Property(u => u.Guid).HasColumnName("guid").HasMaxLength(36).IsRequired();
            builder.Property(u => u.Username).HasColumnName("username").HasMaxLength(50).IsRequired();
            builder.Property(u => u.LastLoginAtUnixTimestamp).HasColumnName("last_login_at_unix_timestamp").IsRequired();
            builder.Property(u => u.CreatedAtUnixTimestamp).HasColumnName("created_at").IsRequired();
            builder.Property(u => u.UpdatedAtUnixTimestamp).HasColumnName("updated_at").IsRequired();
            builder.Property(u => u.Gender).HasColumnName("gender").HasMaxLength(2).IsRequired();
            builder.Property(u => u.Age).HasColumnName("age");
            builder.Property(u => u.Height).HasColumnName("height");
            builder.Property(u => u.Weight).HasColumnName("weight");
            builder.Property(u => u.AlcoholConsumption).HasColumnName("alcohol_consumption").HasMaxLength(2).IsRequired();
        }
    }
}