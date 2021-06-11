using Messenger.Store.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Messenger.Store
{
    public sealed class ChatRepository
    {
        private readonly StoreContext store;

        public ChatRepository(StoreContext store)
        {
            this.store = store;
        }

        public async Task<bool> AddChat(Chat chat)
        {
            if (chat.Name is null) { return false; }

            await store.Chats.AddAsync(chat);
            await store.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Chat>> GetChats()
        {
            var chats = await store.Chats
                .ToArrayAsync();

            return chats;
        }
    }
}
