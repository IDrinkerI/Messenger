using Messenger.Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Messenger.Store.Configuration
{
    internal sealed class MessageEntityConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            var messageText = nameof(Message.MessageText);
            builder.Property(messageText).HasMaxLength(4096);
            builder.Property(messageText).IsRequired();

            builder.Property(nameof(Message.Chat)).IsRequired();
            builder.Property(nameof(Message.Profile)).IsRequired();
        }
    }
}