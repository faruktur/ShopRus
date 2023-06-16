using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopRus.UserService.Domain.Entities;

namespace ShopRus.UserService.Infrastructure.EntityConfigurations
{
    public class UserTypeEntityConfiguration : IEntityTypeConfiguration<UserTypeEntity>
    {
        public const string USER_TABLE_NAME = "Users";
        public void Configure(EntityTypeBuilder<UserTypeEntity> builder)
        {
            builder.ToTable("UserTypes");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
            .UseHiLo("user_type_hilo")
            .IsRequired();

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}
