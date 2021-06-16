using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Messenger.Data.Configuration
{
    internal sealed class AuthInfoEntityConfiguration : IEntityTypeConfiguration<AuthInfoEntity>
    {
        public void Configure(EntityTypeBuilder<AuthInfoEntity> builder)
        {
            //builder.Property(nameof(AuthInfo.PasswordHash)).IsRequired();
        }
    }
}