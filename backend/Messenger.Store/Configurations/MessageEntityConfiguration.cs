using Messenger.Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Messenger.Store.Configuration
{
    internal sealed class MessageEntityConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(nameof(Message.MessageText)).HasMaxLength(4096);
        }
    }
}