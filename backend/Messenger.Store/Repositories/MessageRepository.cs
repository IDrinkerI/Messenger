using Messenger.Store.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Messenger.Store
{
    public sealed class MessageRepository : IRepository<Message>
    {
        private readonly StoreContext _store;

        public MessageRepository(StoreContext store)
        {
            _store = store;
        }

        public async Task<bool> Add(Message message)
        {
            if (message is null ||
                message.UserName is null)
            {
                return false;
            }

            var chat = await _store.Chats.FirstOrDefaultAsync(chat => chat.Id == message.ChatId);
            // TODO: alter this trash
            if (chat is null) { return false; }

            await _store.Messages.AddAsync(message);
            await _store.SaveChangesAsync();

            return true;
        }

        // TODO: remake method for interface
        public async Task<IEnumerable<Message>> GetMessages(int chatId)
        {
            var messages = await _store.Messages.Where(m => m.ChatId == chatId)
                .ToArrayAsync();

            return messages;
        }

        public Task<IEnumerable<Message>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, Message newState)
        {
            throw new NotImplementedException();
        }

        Task<Message> IRepository<Message>.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
