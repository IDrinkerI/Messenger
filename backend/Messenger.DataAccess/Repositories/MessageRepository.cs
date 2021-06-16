using Messenger.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Messenger.DataAccess
{
    public sealed class MessageRepository : IMessageRepository<MessageEntity>
    {
        private readonly StoreContext store;

        public MessageRepository(StoreContext store) => this.store = store;

        async Task IRepository<MessageEntity>.Add(MessageEntity item)
        {
            if (item is null) { return; }

            await store.Messages.AddAsync(item);
            await store.SaveChangesAsync();
        }

        async Task<MessageEntity> IRepository<MessageEntity>.Get(int id)
        {
            var message = await store.Messages
                .FirstOrDefaultAsync(m => m.Id == id);

            return message;
        }

        async Task<IEnumerable<MessageEntity>> IMessageRepository<MessageEntity>.GetAll(int chatId)
        {
            var messages = await store.Messages.Where(m => m.ChatId == chatId)
                .Include(nameof(MessageEntity.Profile))
                .ToListAsync();

            return messages;
        }

        Task<IEnumerable<MessageEntity>> IRepository<MessageEntity>.GetAll()
        {
            throw new System.NotImplementedException();
        }

        async Task IRepository<MessageEntity>.Update(int id, MessageEntity newState)
        {
            var message = await store.Messages
                .FirstOrDefaultAsync(m => m.Id == id);

            if (message is null) { return; }

            await message.UpdateState(newState);
            await store.SaveChangesAsync();
        }
    }
}
