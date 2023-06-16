using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopRus.UserService.Domain.Entities;

namespace ShopRus.UserService.Infrastructure.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public const string USER_TABLE_NAME = "Users";
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
            .UseHiLo("user_hilo")
            .IsRequired();

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(u => u.Surname)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(u => u.Email)
             .IsRequired()
             .HasMaxLength(150);

            builder.Property(u => u.ValidationKey)
             .IsRequired();
        }
    }
}
