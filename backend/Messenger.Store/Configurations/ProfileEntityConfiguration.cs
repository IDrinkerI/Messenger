using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Messenger.Data.Configuration
{
    internal sealed class ProfileEntityConfiguration : IEntityTypeConfiguration<ProfileEntity>
    {
        public void Configure(EntityTypeBuilder<ProfileEntity> builder)
        {
            var nickname = nameof(ProfileEntity.Nickname);
            builder.Property(nickname).HasMaxLength(70);
            builder.Property(nickname).IsRequired();

            builder.Property(nameof(ProfileEntity.FirstName)).HasMaxLength(70);
            builder.Property(nameof(ProfileEntity.LastName)).HasMaxLength(70);
        }
    }
}