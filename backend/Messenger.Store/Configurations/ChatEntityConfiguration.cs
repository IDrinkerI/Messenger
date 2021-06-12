using Messenger.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Messenger.Data.Configuration
{
    internal sealed class ChatEntityConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            var name = nameof(Chat.Name);
            builder.Property(name).HasMaxLength(70);
            builder.Property(name).IsRequired();
        }
    }
}