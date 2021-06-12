using Messenger.Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Messenger.Store.Configuration
{
    internal sealed class AuthInfoEntityConfiguration : IEntityTypeConfiguration<AuthInfo>
    {
        public void Configure(EntityTypeBuilder<AuthInfo> builder)
        {
            //builder.Property(nameof(AuthInfo.PasswordHash)).IsRequired();
        }
    }
}