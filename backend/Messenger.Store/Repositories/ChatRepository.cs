using Messenger.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Data
{
    public sealed class ChatRepository
    {
        private readonly StoreContext _store;

        public ChatRepository(StoreContext store)
        {
            _store = store;
        }

        public async Task<bool> AddChat(Chat chat)
        {
            if(chat.Name is null) { return false; }

            await _store.Chats.AddAsync(chat);
            await _store.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Chat>> GetChats()
        {
            var chats = await _store.Chats
                .ToArrayAsync();

            return chats;
        }
    }
}
