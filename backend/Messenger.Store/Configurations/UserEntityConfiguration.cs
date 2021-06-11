using Messenger.Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Messenger.Store.Configuration
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(nameof(User.Email)).HasMaxLength(500);
            builder.Property(nameof(User.Password)).HasMaxLength(64);
        }
    }
}