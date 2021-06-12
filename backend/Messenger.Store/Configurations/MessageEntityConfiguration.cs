using Messenger.Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Messenger.Store.Configuration
{
    internal sealed class MessageEntityConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            var text = nameof(Message.Text);
            builder.Property(text).HasMaxLength(4096);
            builder.Property(text).IsRequired();

            builder.Property(nameof(Message.ProfileId)).IsRequired();
        }
    }
}