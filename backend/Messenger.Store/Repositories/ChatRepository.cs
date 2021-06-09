using Messenger.Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Store
{
    public sealed class ChatRepository : IRepository<Chat>
    {
        private readonly StoreContext _store;

        public ChatRepository(StoreContext store)
        {
            _store = store;
        }

        public async Task<bool> Add(Chat chat)
        {
            if (chat.Name is null) { return false; }

            await _store.Chats.AddAsync(chat);
            await _store.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Chat>> GetAll()
        {
            var chats = await _store.Chats
                .ToArrayAsync();

            return chats;
        }

        public Task<Chat> Get(int id)
        {
            throw new NotImplementedException();
        }


        public Task<bool> Update(int id, Chat newState)
        {
            throw new NotImplementedException();
        }
    }
}
