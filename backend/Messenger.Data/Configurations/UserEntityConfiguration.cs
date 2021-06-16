using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Messenger.Data.Configuration
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            var email = nameof(UserEntity.Email);
            builder.Property(email).HasMaxLength(500);
            builder.Property(email).IsRequired();

            //var password = nameof(User.AuthInfo);
            //builder.Property(password).IsRequired();
        }
    }
}