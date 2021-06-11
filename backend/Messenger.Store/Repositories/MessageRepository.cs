using Messenger.Store.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Messenger.Store
{
    public sealed class MessageRepository
    {
        private readonly StoreContext store;

        public MessageRepository(StoreContext store)
        {
            this.store = store;
        }

        public async Task<bool> AddMessage(Message message)
        {
            if (message is null) { return false; }

            var chat = await store.Chats.FirstOrDefaultAsync(chat => chat.Id == message.ChatId);
            // TODO: alter this trash
            if (chat is null) { return false; }

            await store.Messages.AddAsync(message);
            await store.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Message>> GetMessages(int chatId)
        {
            var messages = await store.Messages.Where(m => m.ChatId == chatId)
                .ToArrayAsync();

            return messages;
        }
    }
}
