using Messenger.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Messenger.Data.Configuration
{
    internal sealed class SessionEntityConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(nameof(Session.Token)).IsRequired();
            builder.Property(nameof(Session.KillingTime)).IsRequired();
            builder.Property(nameof(Session.UserId)).IsRequired();
        }
    }
}