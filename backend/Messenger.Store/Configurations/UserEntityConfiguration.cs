using Messenger.Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Messenger.Store.Configuration
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var email = nameof(User.Email);
            builder.Property(email).HasMaxLength(500);
            builder.Property(email).IsRequired();

            //var password = nameof(User.AuthInfo);
            //builder.Property(password).IsRequired();
        }
    }
}