using Messenger.Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Messenger.Store.Configuration
{
    internal sealed class ProfileEntityConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            var nickname = nameof(Profile.Nickname);
            builder.Property(nickname).HasMaxLength(70);
            builder.Property(nickname).IsRequired();

            builder.Property(nameof(Profile.FirstName)).HasMaxLength(70);
            builder.Property(nameof(Profile.LastName)).HasMaxLength(70);
        }
    }
}