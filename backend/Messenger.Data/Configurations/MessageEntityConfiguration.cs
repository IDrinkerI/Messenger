using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Messenger.Data.Configuration
{
    internal sealed class MessageEntityConfiguration : IEntityTypeConfiguration<MessageEntity>
    {
        public void Configure(EntityTypeBuilder<MessageEntity> builder)
        {
            var text = nameof(MessageEntity.Text);
            builder.Property(text).HasMaxLength(4096);
            builder.Property(text).IsRequired();

            //builder.Property(nameof(Message.ProfileId)).IsRequired();
        }
    }
}