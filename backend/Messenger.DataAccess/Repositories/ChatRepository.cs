using Messenger.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Messenger.Data;


namespace Messenger.DataAccess
{
    public sealed class ChatRepository : IRepository<ChatEntity>
    {
        private readonly StoreContext store;

        public ChatRepository(StoreContext store)
        {
            this.store = store;
        }

        async Task IRepository<ChatEntity>.Add(ChatEntity item)
        {
            if (item is null) { return; }

            await store.Chats.AddAsync(item);
            await store.SaveChangesAsync();
        }

        async Task<ChatEntity> IRepository<ChatEntity>.Get(int id)
        {
            var chat = await store.Chats
                .FirstOrDefaultAsync(c => c.Id == id);

            return chat;
        }

        async Task<IEnumerable<ChatEntity>> IRepository<ChatEntity>.GetAll()
        {
            var chats = await store.Chats
                .ToArrayAsync();

            return chats;
        }

        async Task IRepository<ChatEntity>.Update(int id, ChatEntity newState)
        {
            var chat = await store.Chats
                .FirstOrDefaultAsync(c => c.Id == id);

            if (chat is null) { return; }

            chat = newState;
            await store.SaveChangesAsync();
        }
    }
}
