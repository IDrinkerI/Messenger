using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Messenger.Data.Configuration
{
    internal sealed class ChatEntityConfiguration : IEntityTypeConfiguration<ChatEntity>
    {
        public void Configure(EntityTypeBuilder<ChatEntity> builder)
        {
            var name = nameof(ChatEntity.Name);
            builder.Property(name).HasMaxLength(70);
            builder.Property(name).IsRequired();
        }
    }
}