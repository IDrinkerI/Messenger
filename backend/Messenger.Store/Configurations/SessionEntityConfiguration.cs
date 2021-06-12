using Messenger.Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Messenger.Store.Configuration
{
    internal class SessionEntityConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(nameof(Session.Token)).IsRequired();
            builder.Property(nameof(Session.KillingTime)).IsRequired();
            builder.Property(nameof(Session.User)).IsRequired();
        }
    }
}