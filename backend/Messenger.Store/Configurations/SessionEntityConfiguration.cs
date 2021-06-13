using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Messenger.Data.Configuration
{
    internal sealed class SessionEntityConfiguration : IEntityTypeConfiguration<SessionEntity>
    {
        public void Configure(EntityTypeBuilder<SessionEntity> builder)
        {
            builder.Property(nameof(SessionEntity.Token)).IsRequired();
            builder.Property(nameof(SessionEntity.KillingTime)).IsRequired();
            builder.Property(nameof(SessionEntity.UserId)).IsRequired();
        }
    }
}